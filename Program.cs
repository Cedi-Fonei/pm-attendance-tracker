using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Attendance_Tracker
{
    /*
     CURRENT HURDLE: Troubleshooting why the bot, as it is currently built, will not recognize message content.
    It can recognize that a message has been sent, but it cannot parse what has been said (therefore, it cannot parse commands)

    ? Is this a permissions issue?
    ?? Is this some other setting I need to reconfigure correctly within the Discord Developer Portal?
    ? Is this an error in how I set up the client in the code below?
     */

    public class Program
    {
        private static DiscordSocketClient _client;
        private static CommandService _commands;

        public static async Task Main()
        {
            _client = new DiscordSocketClient();

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
            Console.WriteLine($"I have heard something...[{messageParam.CleanContent}]. Channel is {messageParam.Channel}");

            // Don't process the command if it was a system message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            
            Console.WriteLine("It is a SockerUserMessage...");

            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;

            
            if(!message.HasCharPrefix('!', ref argPos)){
                Console.WriteLine("The message DOES NOT start with an !...");
            }

            // TROUBLESHOOTING FINDINGS - HandleCommandAsync returns without processing the test commands BECAUSE it thinks the message is always blank and thus message.HasCharPrefix('!', ref argPos) is always false
            // Determine if the message is a command based on the prefix and make sure no bots trigger commands
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
        [Command("ping")]
        [Summary("A test ping.")]
        public async Task PingAsync()
        {
            Console.WriteLine("Attempting to ping...");
            await Context.Channel.SendMessageAsync("Pong!");
        }
    }

    [Group("record-attendance")]
    public class RecordingModule : ModuleBase<SocketCommandContext>
    {
        [Command("start")]
        [Summary("!TBD! Starts tracking attendance for the current meeting.")]
        public async Task StartAsync()
        {
            Console.WriteLine("Attempting to START recording...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }

        [Command("stop")]
        [Summary("!TBD! Stops tracking attendance for the current meeting.")]
        public async Task EndAsync()
        {
            Console.WriteLine("Attempting to STOP recording...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }
    }
}
