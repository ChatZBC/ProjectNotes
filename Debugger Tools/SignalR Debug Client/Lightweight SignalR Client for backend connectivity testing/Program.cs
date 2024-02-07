using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7206/chatHub")
            .Build();

        // Listen for "MessageReceived" events
        connection.On<string, string>("MessageReceived", (user, message) =>
        {
            Console.WriteLine($"Received message from {user}: {message}");
        });

        try
        {
            await connection.StartAsync();
            Console.WriteLine("Connected to the ChatHub.");

            // To test sending a message that should be logged and broadcasted
            // Adjust parameters as necessary for your testing
            await connection.InvokeAsync("SendMessage", "LightweightBackendClient", "Hello from the backend client!");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            await connection.DisposeAsync();
        }
    }
}
