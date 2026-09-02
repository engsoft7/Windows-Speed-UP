# Windows Speed-UP (Ultra IA Optimizer) 🚀⚡

Uma ferramenta de otimização nativa em C# para Windows focada em extrair o máximo de performance absoluta do seu hardware, especialmente desenhada para diminuir o *Input Lag* e aumentar o FPS em jogos eliminando gargalos de CPU e Disco.

## 📂 Estrutura de Arquivos do Projeto

Como a ferramenta foi evoluindo durante o desenvolvimento, vários arquivos compõem o repositório atual:

- **`UltraIA_GodMode.exe`**: 👑 **(Recomendado)** A versão final e suprema da IA já compilada e pronta para uso. Contém o Timer Hack de latência (1ms), Core Isolation dinâmico e proteção de tela cheia (Beast Mode). É esse arquivo que você deve usar.
- **`UltraIA.cs`**: O código-fonte principal escrito em C#. Contém toda a lógica estrutural e o mapeamento das APIs nativas do Windows (`kernel32.dll`, `user32.dll`, `winmm.dll`). Útil se você for desenvolvedor, quiser revisar o código ou recompilar o sistema por conta própria.
- **`UltraIA.exe` / `UltraOptimizer.exe`**: Versões anteriores/estáveis (V2.0) do executável. Elas funcionam perfeitamente para controle de CPU, mas não possuem o "Timer Hack extremo" do God Mode embutido.
- **`icone.ico`**: O ícone exclusivo (Neon) desenhado para injetar na interface do executável.
- **`adicionar_icone.ps1`**: Script em PowerShell utilizado para desenhar dinamicamente o ícone vetorial e para forçar o compilador nativo do Windows (`csc.exe`) a acoplar esse ícone ao código fonte.

## 🔥 Funcionalidades (God Mode)

- **Zero Latency (Timer Hack):** Altera o Relógio de Interrupção do Windows via Multimídia Kernel (`timeBeginPeriod`) para **1 milissegundo**, reduzindo a latência de periféricos ao mínimo possível pela placa-mãe.
- **Foreground Priority Boost:** Rastreia qual janela o usuário está olhando e injeta dinamicamente `Prioridade Alta` direto no processo ativo.
- **Beast Mode (Detecção de Tela Cheia):** Ao detectar que um jogo ou programa ocupou a tela inteira, a IA entra em protocolo restrito:
  1. **Core Isolation:** Força todos os aplicativos paralelos e processos não-vitais a rodarem enjaulados **apenas na CPU 0**, liberando os demais núcleos 100% para a Tela Cheia.
  2. **I/O Suppression:** Rebaixa processos de segundo plano para prioridade `Idle`, bloqueando que eles acessem o SSD intensamente e causem *stuttering* no meio de uma partida.
- **Auto-Recovery Inteligente:** Ao minimizar ou fechar o jogo, destranca os núcleos e restaura os discos e as prioridades automaticamente.

## 🛠️ Como usar (Modo Fantasma)

O sistema roda nativamente em modo *Windowless* (nenhuma interface ou terminal vai poluir sua tela).

Para instalar, basta apertar `Win + R`, digitar `shell:startup` e colar o executável **`UltraIA_GodMode.exe`** lá dentro. Ele rodará automaticamente e silenciosamente toda vez que o Windows iniciar.
