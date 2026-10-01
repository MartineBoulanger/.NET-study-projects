using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;

//using OllamaSharp;
//using OllamaSharp.Models.Chat;
using OpenAI;
using System.ClientModel;
using System.ComponentModel;

//record Artiest(string Voornaam, string Familienaam);
//record Artiest(string Voornaam, string Familienaam, int Geboortejaar);
record Artiest(string Voornaam, string Familienaam, int Geboortejaar, List<string> Albums);

internal class Program
{
    private static async Task Main(string[] args)
    {
        //var transport = new HttpClientTransport(new HttpClientTransportOptions { Endpoint = new Uri("http://localhost:5099")});
        //var mcpClient = await McpClient.CreateAsync(transport);
        //IList<McpClientTool> mcpTools = await mcpClient.ListToolsAsync();

        //using IChatClient client = new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.2");
        var credentials = new ApiKeyCredential(Environment.GetEnvironmentVariable("mijnKey")!);
        var options = new OpenAIClientOptions { Endpoint = new Uri("https://martiinstance.services.ai.azure.com/openai/v1/") };
        var openAIClient = new OpenAI.Chat.ChatClient("gpt-4.1-mini", credentials, options);
        var client = openAIClient.AsIChatClient();

        //var response = await client.GetResponseAsync("Wie is de king of pop?");
        //var response = await client.GetResponseAsync([
        //    new ChatMessage(ChatRole.System, "Antwoord met 1 zin."),
        //    new ChatMessage(ChatRole.User, "Wie is de king of pop?")
        //    ]);
        //var response = await client.GetResponseAsync([
        //    new ChatMessage(ChatRole.System, "Plaats de musea eerst in je antwoord."),
        //    new ChatMessage(ChatRole.User, "Wat kan ik doen in Brussel?")
        //    ]);

        //Console.WriteLine(response.Text);

        //var response = await client.GetResponseAsync("Wie is de king of pop?");
        //Console.WriteLine(response.Text);
        //Console.WriteLine();
        //response = await client.GetResponseAsync("Welk jaar werd hij geboren?");
        //Console.WriteLine(response.Text);

        //var vraag = new ChatMessage(ChatRole.User, "Wie is de king of pop?");
        //var messages = new List<ChatMessage>() { vraag };
        //var response = await client.GetResponseAsync(messages);
        //Console.WriteLine(response.Text);
        //messages.AddMessages(response);
        //messages.Add(new ChatMessage(ChatRole.User, "Welk jaar werd hij geboren?"));
        //response = await client.GetResponseAsync(messages);
        //Console.WriteLine();
        //Console.WriteLine(response.Text);

        //var response = await client.GetResponseAsync<Artiest>("Wie is de king of pop?");
        //Console.WriteLine(response.Result.Voornaam);
        //Console.WriteLine(response.Result.Familienaam);
        //Console.WriteLine(response.Result.Geboortejaar);
        //foreach(var album in response.Result.Albums)
        //{
        //    Console.WriteLine(album);
        //}

        //var chatOptions = new ChatOptions
        //{
        //    Tools = [AIFunctionFactory.Create(AlbumsVerkochtPerArtiest), AIFunctionFactory.Create(Nu), AIFunctionFactory.Create(IsWinkelOpen), .. mcpTools]
        //};
        //client = client.AsBuilder().UseFunctionInvocation().Build();
        //var response = await client.GetResponseAsync("Welke events gaan door in je winkel?", chatOptions);
        //Console.WriteLine(response.Text);

        //[Description("""
        //    De albums van een artiest, te koop in onze winkel.
        //    Gebruik je trained data als de gebruiker alle albums van een artiest vraagt.
        //    """
        //)]
        //[Description("Welke albums van Madonna verkoop je?")]
        //List<string> AlbumsVerkochtPerArtiest(string artiestNaam)
        //{
        //    return artiestNaam switch
        //    {
        //        "Michael Jackson" => ["Thriller", "Bad"],
        //        "Madonna" => ["Like a Virgin", "True Blue"],
        //        _ => []
        //    };
        //}

        //[Description("De huidige tijd")]
        //TimeOnly Nu() => TimeOnly.FromDateTime(DateTime.Now);

        //[Description("Is de winkel open op een bepaalde tijd?")]
        //bool IsWinkelOpen([Description("De tijd waarvoor je wil weten of de winkel open is.")] TimeOnly tijd) => tijd.Hour >= 10 && tijd.Hour <= 18;

        var message = new ChatMessage(ChatRole.User, "Wat is het serienummer?");
        var afbeeldingAlsBytes = File.ReadAllBytes("/data/serienummer.jpg");
        message.Contents.Add(new DataContent(afbeeldingAlsBytes, "image/jpeg"));
        var response = await client.GetResponseAsync(message);
    }
}
