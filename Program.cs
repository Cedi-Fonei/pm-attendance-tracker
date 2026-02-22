using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Attendance_Tracker
{
    public class Program
    {
        private static DiscordSocketClient _client;
        private static CommandService _commands;

        public static async Task Main()
        {
            var socketConfig = new DiscordSocketConfig
            {
                AlwaysDownloadUsers = true,
                MessageCacheSize = 100,
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent

            };
            _client = new DiscordSocketClient(socketConfig);

            _commands = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Info,
                CaseSensitiveCommands = false,
            });

            _client.Log += Log;
            _commands.Log += Log;

            /*
             For security & simplicity purposes, I'm keeping the token for the bot in a local-only file.
            This token is not included in the repo, and the bot will NOT login & start without it. This is an intentional security measure.
            When developing & running locally, the token belongs in the "{project directory}\bin\Debug\net8.0" folder

            When handing off the bot for running in a real meeting, I'll also hand off the token file with some additional instructions.
             */
            var token = File.ReadAllText("token.txt");
            
            await _commands.AddModuleAsync<TestModule>(null);
            await _commands.AddModuleAsync<RecordingModule>(null);

            _client.MessageReceived += HandleCommandAsync;
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            Console.WriteLine("Bot is started!");

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }


        private static async Task HandleCommandAsync(SocketMessage messageParam)
        {
            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            
            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            if (!(message.HasCharPrefix('!', ref argPos) ||
                message.HasMentionPrefix(_client.CurrentUser, ref argPos)) ||
                message.Author.IsBot)
                return;

            Console.WriteLine("I have received a message that starts with a ! symbol...");

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
                services: null);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }






    public class TestModule : ModuleBase<SocketCommandContext>
    {
        [Command("ping")] //!ping
        [Summary("A test ping.")]
        public async Task PingAsync()
        {
            Console.WriteLine("Attempting to ping...");
            await Context.Channel.SendMessageAsync("Pong!"); //Success!!!
        }
    }

    [Group("record-attendance")]
    public class RecordingModule : ModuleBase<SocketCommandContext>
    {
        [Command("start")] //!record-attendance start
        [Summary("!TBD! Starts tracking attendance for the current meeting.")]
        public async Task StartAsync()
        {
            Console.WriteLine("Attempting to START recording...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }

        [Command("stop")] //!record-attendance stop
        [Summary("!TBD! Stops tracking attendance for the current meeting.")]
        public async Task EndAsync()
        {
            Console.WriteLine("Attempting to STOP recording...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }
    }
}
