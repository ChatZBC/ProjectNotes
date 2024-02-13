using Microsoft.AspNetCore.SignalR.Client;

namespace Lightweight_SignalR_Client_for_backend_connectivity_testing
{
        /*
        * Refactored code from Program.cs
        * 
        */
    public class ChatClient
    {
        private readonly string _username; // Client's username
        private readonly HubConnection _connection; // Hub Connection

        // Connection strings
        private static readonly string _localConnection = "https://localhost:7206/chatHub";
        private readonly string _connectionString = "http://192.168.1.246:8080/chatHub";

        /// <summary>
        /// Builds a connections from the HubConnectionBuilder
        /// </summary>
        /// <param name="username">passed as query parameter</param>
        public ChatClient(string username)
        {
            _username = username;
            _connection = new HubConnectionBuilder()
                .WithUrl($"{_localConnection}?username={_username}")
                .Build();
        }


        // Start connection and add listeners
        public async Task StartAsync()
        {
            _connection.On<string, string>("MessageReceived", (user, message) =>
            {
                Console.WriteLine($"Received message from {user}: {message}");
            });

            _connection.On<string>("error", (err) =>
            {
                Console.WriteLine($"error: {err}");
                throw new Exception(err);
            });

            _connection.On<string>("adduser", (user) =>
            {
                Console.WriteLine($"{user} has joined the chat");
            });

            await _connection.StartAsync();
        }

        /// <summary>
        /// Disposes connection
        /// </summary>
        /// <returns></returns>
        public async Task DisposeAsync()
        {
            await _connection.DisposeAsync();
        }

        /// <summary>
        /// Sends a message to server
        /// </summary>
        /// <param name="message">Message content</param>
        /// <returns></returns>
        public async Task SendMessageAsync(string message)
        {
            await _connection.SendAsync("SendMessage", _username, message);
        }

        /// <summary>
        /// Retrieve active user list
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> RequestUserListAsync()
        {
            return await _connection.InvokeAsync<List<string>>("RequestUserList", _username);
        }
    }
}
