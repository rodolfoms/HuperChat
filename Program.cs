using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Google.GenAI;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

string apiKey = config["Gemini:ApiKey"] ??
    throw new InvalidOperationException("Gemini API key is not configured.");

IChatClient chat = new Client(apiKey: apiKey)
    .AsIChatClient("gemini-2.5-flash");

// 1 - A lista principal do histórico deve ser de ChatMessage (mensagens completas)
List<ChatMessage> conversationHistory = [];

while (true)
{
    Console.WriteLine("Enter your message (or type 'exit' to quit):");
    string? userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput) ||
        userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    // 2 - Adiciona a mensagem completa do usuário ao histórico
    conversationHistory.Add(new ChatMessage(ChatRole.User, userInput));

    // 3 - Cria uma lista temporária para acumular os pedaços (chunks) do streaming atual
    List<ChatResponseUpdate> updates = [];

    // 4 - Envia o histórico COMPLETO (conversationHistory) para manter o contexto da conversa
    await foreach (var update in chat.GetStreamingResponseAsync(conversationHistory))
    {
        Console.Write(update.Text);

        // 5 - Adiciona o chunk atual na lista temporária 'updates'
        updates.Add(update);
    }

    Console.WriteLine();

    // 6 - Converte os chunks acumulados em uma ChatMessage completa e salva no histórico principal
    conversationHistory.AddMessages(updates);
}