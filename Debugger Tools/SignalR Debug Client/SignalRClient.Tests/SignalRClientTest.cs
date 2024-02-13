using Lightweight_SignalR_Client_for_backend_connectivity_testing;
using Xunit;

namespace SignalRClient.Tests
{
    public class SignalRClientTest
    {
        [Theory]
        [InlineData("Hello world")]
        [InlineData("This message contains profanity")]
        [InlineData("This message contains issues")]
        [InlineData("This message contains commands such as /kick william")]

        public async Task SendMessageAsync_ShouldSendMessage(string message)
        {
            // Arrange
            var chatClient = new ChatClient("CSharp");
            // Connect
            await chatClient.StartAsync();
            // Assert
            await chatClient.SendMessageAsync(message);

            // End
            await chatClient.DisposeAsync();
        }

        [Fact]
        public async Task RequestUserListAsync_ShouldRetrieveUserList()
        {

            // Arrange
            var chatClient = new ChatClient("C-Sharp lightweightclient");

            await chatClient.StartAsync();

            // Act
            List<string> results = await chatClient.RequestUserListAsync();

            // Assert
            Assert.NotNull(results);

            // End
            await chatClient.DisposeAsync();
        }
    }
}
