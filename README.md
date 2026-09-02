# Windows Speed-UP (UltraOptimizer) 🚀

[![Platform: Windows](https://img.shields.io/badge/Platform-Windows%2010%20%7C%2011-blue.svg)]()
[![Language: C#](https://img.shields.io/badge/Language-C%23-239120.svg)]()
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)]()

**Windows Speed-UP** é um *daemon* nativo de otimização de sistema escrito em C# e focado em extrair o máximo de performance de processadores em ambientes Windows. Desenvolvido para mitigar problemas de latência (*Input Lag*) e *stuttering* (quedas bruscas de quadros) durante cargas de trabalho pesadas e sessões de jogos.

## ⚙️ Arquitetura e Funcionamento

Diferente de otimizadores genéricos que prometem resultados através da simples limpeza de arquivos temporários, o **UltraOptimizer** atua diretamente no *Scheduler* (Escalonador) do Windows, interagindo através de P/Invoke com as bibliotecas nativas `kernel32.dll`, `user32.dll` e `winmm.dll`.

Para atestar sua credibilidade e eficiência, o sistema foi projetado para consumir **~0% de CPU**. Ele opera através de chamadas em *Thread.Sleep* (polling a cada 1500ms), garantindo que a própria ferramenta seja assíncrona e não gere nenhum *overhead* (peso) no sistema.

### Principais Funcionalidades Técnicas

1. **Timer Resolution Tuning (1ms)**  
   O sistema operacional Windows utiliza uma resolução de interrupção (Timer Resolution) padrão de 15.6ms. A ferramenta utiliza a API Multimídia do Kernel (`timeBeginPeriod`) para forçar o sistema a trabalhar com uma resolução de **1 milissegundo**. Isso resulta em uma diminuição substancial do tempo de resposta da CPU a periféricos (mouses e teclados de alta precisão).

2. **Foreground Priority Injection (Dynamic QoS)**  
   Através da API `GetForegroundWindow`, o daemon rastreia a aplicação atualmente em foco pelo usuário. Ele injeta dinamicamente a classe de prioridade `High` no processo ativo, garantindo que o Escalonador do Windows priorize o tempo de CPU para a aplicação principal acima de processos de background.

3. **Core Isolation & Beast Mode (Heurística de Tela Cheia)**  
   Quando uma aplicação (como um jogo ou software de renderização 3D) entra em estado de *Fullscreen*, o protocolo de contenção é ativado:
   - **Restrição de Afinidade (Affinity Masking):** Processos não-críticos em segundo plano têm sua execução restrita obrigatoriamente à **CPU 0**. Isso evita a saturação do cache L3 do processador e libera 100% dos demais núcleos físicos exclusivamente para a aplicação em foco.
   - **I/O Suppression:** A prioridade de memória e paginação desses processos secundários é rebaixada para `Idle`, mitigando interrupções bruscas de leitura no disco (SSD/HDD) que comumente causam o micro-stuttering.

4. **Auto-Recovery Inteligente**  
   Ao fechar ou minimizar a aplicação principal, a máscara de afinidade e as prioridades dos processos secundários são imediatamente restauradas para os padrões originais do Windows, preservando a estabilidade a longo prazo do sistema.

## 📂 Estrutura do Repositório

- **`UltraIA_GodMode.exe`**: 👑 **(Release Principal)** A versão final compilada (`winexe`). Contém o Tuning de Latência, Isolamento Dinâmico de Núcleos e Foreground Tracking. Pronto para uso.
- **`UltraIA.cs`**: O código-fonte principal (C#). Contém todo o mapeamento e lógica de chamadas nativas do Windows.
- **`icone.ico` & `adicionar_icone.ps1`**: Assets visuais e o script de compilação automatizada utilizando o compilador `csc.exe` nativo do .NET Framework.

## 🛠️ Instalação (Standalone)

A aplicação é distribuída como um executável *Standalone Windowless* (não requer instalação de dependências externas, Frameworks pesados ou interfaces visuais em background).

1. Pressione `Win + R` e digite `shell:startup`.
2. Cole o arquivo **`UltraIA_GodMode.exe`** dentro da pasta.
3. A otimização será executada de forma invisível em segundo plano (em nível de sistema) toda vez que o Sistema Operacional for iniciado.
