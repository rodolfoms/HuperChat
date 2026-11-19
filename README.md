# Gemini Console Chat com Microsoft.Extensions.AI

Aplicação de console em .NET que demonstra como integrar o modelo **Google Gemini (`gemini-2.5-flash`)** utilizando as abstrações oficiais do **`Microsoft.Extensions.AI`** (`IChatClient`), com suporte a respostas em tempo real (streaming), histórico de conversa em memória e gerenciamento seguro de credenciais via .NET User Secrets.

## 🚀 Funcionalidades

* **Abstração Agnóstica de Provedor:** Utiliza `IChatClient` do `Microsoft.Extensions.AI`, facilitando a troca de modelos ou provedores no futuro sem alterar a lógica do chat.
* **SDK Oficial do Google:** Integração nativa através do pacote `Google.GenAI`.
* **Respostas em Streaming:** Exibição token por token no console via `GetStreamingResponseAsync`.
* **Memória de Contexto:** Acumula e mantém o histórico completo da sessão (`List<ChatMessage>`) para conversas contínuas.
* **Segurança de Credenciais:** Leitura da chave de API via `Microsoft.Extensions.Configuration.UserSecrets`, evitando exposição de chaves no código-fonte.

## 📋 Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download) ou superior
* Uma chave de API válida do [Google AI Studio](https://aistudio.google.com/)

## 📦 Pacotes NuGet Utilizados

* `Google.GenAI`
* `Microsoft.Extensions.AI`
* `Microsoft.Extensions.Configuration.UserSecrets`

## ⚙️ Configuração e Instalação

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
   cd seu-repositorio