# Windows Speed-UP (Ultra IA Optimizer) 🚀⚡

Uma ferramenta de otimização nativa em C# para Windows focada em extrair o máximo de performance absoluta do seu hardware, especialmente desenhada para diminuir o *Input Lag* e aumentar o FPS em jogos eliminando gargalos de CPU e Disco.

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
