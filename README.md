# Windows Speed-UP (Ultra IA Optimizer) 🚀⚡

Uma ferramenta de otimização nativa em C# para Windows focada em extrair o máximo de performance absoluta do seu hardware, especialmente desenhada para diminuir o *Input Lag* e aumentar o FPS em jogos eliminando gargalos de CPU e Disco.

## 🧠 Como a Mágica Funciona? (Explicação Simples para Leigos)

Se você não entende muito de computadores, imagine o seguinte:
O Windows é como um **cruzamento de trânsito muito movimentado**. Quando você está jogando e, de repente, o antivírus ou o navegador resolvem fazer alguma coisa no fundo, o Windows tenta dar atenção para todo mundo ao mesmo tempo. É nesse momento que o seu jogo "engasga" ou perde desempenho (cai o FPS).

O que o **UltraIA** faz é agir como um **Policial de Trânsito** extremamente rigoroso direto no motor do computador:
- **O poder segue seus olhos:** No momento em que você clica em uma janela ou jogo, a IA dá uma carteirada no Windows: *"Parem tudo! Prioridade máxima para esse programa agora!"*
- **A Prisão (Isolamento de Núcleos):** Se você abrir o jogo em Tela Cheia, a IA pega todos os outros aplicativos (Spotify, abas do Chrome, etc.) e "tranca" eles em apenas **um cantinho do processador** (o Núcleo 0). Assim, todo o restante do seu processador fica 100% limpo e focado só no seu jogo.

**Isso demora para fazer efeito?**
Não! O efeito é **imediato**. Diferente de algoritmos lentos que "aprendem", esta IA aplica regras militares na exata fração de segundo em que você maximiza um jogo.

**Por que a IA consome 0% de CPU se ela é tão forte?**
Porque ela age como um atirador de elite. O código foi programado para acordar, fazer as otimizações no processador inteiro em apenas **1 milissegundo**, e depois **dormir profundamente por 1.5 segundos**. Como ela passa 99,9% da vida dela dormindo, ela pesa zero no seu computador.

---

## 📂 Estrutura de Arquivos do Projeto

Como a ferramenta foi evoluindo, vários arquivos compõem o repositório atual:

- **`UltraIA_GodMode.exe`**: 👑 **(Recomendado)** A versão final e suprema da IA já compilada e pronta para uso. Contém o Timer Hack de latência (1ms), Core Isolation dinâmico e proteção de tela cheia (Beast Mode). É esse arquivo que você deve usar.
- **`UltraIA.cs`**: O código-fonte principal escrito em C#. Contém toda a lógica estrutural e o mapeamento das APIs nativas do Windows (`kernel32.dll`, `user32.dll`, `winmm.dll`). Útil se você for desenvolvedor, quiser revisar o código ou recompilar o sistema por conta própria.
- **`icone.ico`**: O ícone exclusivo (Neon) desenhado para injetar na interface do executável.
- **`adicionar_icone.ps1`**: Script em PowerShell utilizado para desenhar dinamicamente o ícone vetorial e para forçar o compilador nativo do Windows (`csc.exe`) a acoplar esse ícone ao código fonte.

## 🔥 Funcionalidades Avançadas (God Mode)

- **Zero Latency (Timer Hack):** Altera o Relógio de Interrupção do Windows via Multimídia Kernel (`timeBeginPeriod`) para **1 milissegundo**, reduzindo a latência de periféricos ao mínimo possível pela placa-mãe.
- **Foreground Priority Boost:** Rastreia qual janela o usuário está olhando e injeta dinamicamente `Prioridade Alta` direto no processo ativo.
- **Beast Mode (Detecção de Tela Cheia):** Ao detectar que um jogo ou programa ocupou a tela inteira, a IA entra em protocolo restrito:
  1. **Core Isolation:** Força todos os aplicativos paralelos e processos não-vitais a rodarem enjaulados **apenas na CPU 0**, liberando os demais núcleos 100% para a Tela Cheia.
  2. **I/O Suppression:** Rebaixa processos de segundo plano para prioridade `Idle`, bloqueando que eles acessem o SSD intensamente e causem *stuttering* no meio de uma partida.
- **Auto-Recovery Inteligente:** Ao minimizar ou fechar o jogo, destranca os núcleos e restaura os discos e as prioridades automaticamente.

## 🛠️ Como usar (Instalação Fácil)

O sistema roda nativamente em modo *Windowless* (nenhuma interface ou terminal vai poluir sua tela).

Para instalar, basta apertar as teclas `Win + R` no seu teclado, digitar `shell:startup` e colar o executável **`UltraIA_GodMode.exe`** lá dentro. 
Pronto! Ele rodará automaticamente e silenciosamente toda vez que você ligar o computador.
