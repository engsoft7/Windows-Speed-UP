using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace UltraOptimizer
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetProcessWorkingSetSize(IntPtr process, UIntPtr minimumWorkingSetSize, UIntPtr maximumWorkingSetSize);

        // API de Multimidia do Windows para controle extremo do Processador
        [DllImport("winmm.dll", EntryPoint = "timeBeginPeriod")]
        public static extern uint TimeBeginPeriod(uint uMilliseconds);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int nIndex);

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        static string[] Whitelist = { "explorer", "dwm", "svchost", "System", "smss", "csrss", "wininit", "services", "lsass", "winlogon", "Taskmgr", "SearchIndexer" };

        static void Main(string[] args)
        {
            // GOD MODE: HACK DA LATÊNCIA DA CPU PARA 1 MILISSEGUNDO!
            TimeBeginPeriod(1);

            int lastForegroundProcId = -1;
            bool wasFullscreen = false;

            const int SM_CXSCREEN = 0;
            const int SM_CYSCREEN = 1;

            while (true)
            {
                try
                {
                    int screenWidth = GetSystemMetrics(SM_CXSCREEN);
                    int screenHeight = GetSystemMetrics(SM_CYSCREEN);

                    IntPtr hwnd = GetForegroundWindow();
                    if (hwnd != IntPtr.Zero)
                    {
                        uint pid;
                        GetWindowThreadProcessId(hwnd, out pid);

                        // DETECTOR DE FULLSCREEN (Lê as dimensões da janela e da tela)
                        bool isFullscreen = false;
                        RECT rect;
                        if (GetWindowRect(hwnd, out rect))
                        {
                            if ((rect.Right - rect.Left) >= screenWidth && (rect.Bottom - rect.Top) >= screenHeight)
                            {
                                isFullscreen = true;
                            }
                        }

                        // INJEÇÃO DE PRIORIDADE ALTA AO APP ATIVO
                        if (pid != lastForegroundProcId && pid > 0)
                        {
                            try
                            {
                                Process fgProc = Process.GetProcessById((int)pid);
                                if (fgProc.PriorityClass != ProcessPriorityClass.High)
                                {
                                    fgProc.PriorityClass = ProcessPriorityClass.High;
                                }
                                // Destranca todos os nucleos para o app principal
                                try { fgProc.ProcessorAffinity = (IntPtr)((1 << Environment.ProcessorCount) - 1); } catch {}
                                
                                lastForegroundProcId = (int)pid;
                            }
                            catch { }
                        }

                        // BEAST MODE ATIVADO (Quando detecta o modo de Tela Cheia de Jogos ou Filmes)
                        if (isFullscreen && !wasFullscreen)
                        {
                            Process[] procs = Process.GetProcesses();
                            foreach (Process p in procs)
                            {
                                try
                                {
                                    if (p.Id != lastForegroundProcId && Array.IndexOf(Whitelist, p.ProcessName) == -1)
                                    {
                                        // 1. ESCUDO DE DISCO: Classe 'Idle' tira acesso preferencial de Leitura do HD/SSD
                                        p.PriorityClass = ProcessPriorityClass.Idle; 
                                        
                                        // 2. ISOLAMENTO DE NÚCLEOS: Prende programas inúteis apenas no Núcleo 0
                                        p.ProcessorAffinity = (IntPtr)1; 
                                    }
                                }
                                catch { }
                            }
                        }
                        
                        // AUTO-RECOVERY (Se sair do jogo, destranca o disco e os processadores)
                        if (!isFullscreen && wasFullscreen)
                        {
                            Process[] procs = Process.GetProcesses();
                            foreach (Process p in procs)
                            {
                                try
                                {
                                    if (p.Id != lastForegroundProcId && Array.IndexOf(Whitelist, p.ProcessName) == -1)
                                    {
                                        p.PriorityClass = ProcessPriorityClass.Normal;
                                        p.ProcessorAffinity = (IntPtr)((1 << Environment.ProcessorCount) - 1);
                                    }
                                }
                                catch { }
                            }
                        }

                        wasFullscreen = isFullscreen;
                    }

                    // O Expurgo de RAM foi removido pois forçar a limpeza causa micro-travamentos (stuttering)
                    // quando os programas precisam ler os dados do disco de volta para a memória.

                    Thread.Sleep(1500);
                }
                catch { }
            }
        }
    }
}
