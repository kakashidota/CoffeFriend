using DSharpPlus;
using DSharpPlus.EventArgs;

namespace CoffeFriend
{
    internal class Program
    {
        static CoffeQueue coffe = new CoffeQueue();
        static async Task Main(string[] args)
        {
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = "",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            discordClient.MessageCreated += OnMessageCreated;
            await discordClient.ConnectAsync();
            await Task.Delay(-1);

        }

        private static async Task OnMessageCreated(DiscordClient client, MessageCreateEventArgs msg)
        {
            
            //1. Adding a person to the queue
            if(string.Equals(msg.Message.Content, "!add", StringComparison.OrdinalIgnoreCase))
            {
                string name = msg.Author.Username;
                Person person = new Person(name);
                coffe.Enqueue(person);
                await msg.Message.RespondAsync($"{name} has been added to the queue");
            }

            //2. Checking the current queue
            if(string.Equals(msg.Message.Content, "!check", StringComparison.OrdinalIgnoreCase))
            {
                await msg.Message.RespondAsync(coffe.ToString());
            }

            //3. Rotates the list by taking out the first person and then adding the same person to the end of the list
            if(string.Equals(msg.Message.Content, "!rotate", StringComparison.OrdinalIgnoreCase))
            {
                coffe.Rotate();
                await msg.Message.RespondAsync(coffe.ToString());
            }

        }
    }
}