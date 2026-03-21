using Attendance_Tracker.Modules;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using System;

namespace Attendance_Tracker
{
    public class Program
    {
        private static DiscordSocketClient _client;
        private static InteractionService _interactionService;

        static Program() {
            var socketConfig = new DiscordSocketConfig {
                GatewayIntents = GatewayIntents.AllUnprivileged
            };
            _client = new DiscordSocketClient(socketConfig);

            var interactionServiceConfig = new InteractionServiceConfig {
                LogLevel = LogSeverity.Debug,
            };
            _interactionService = new InteractionService(_client, interactionServiceConfig);

            _client.Log += Log;
            _interactionService.Log += Log;
        }

        public static async Task Main()
        {
            // when running this bot in production, set the token via one of two ways
            // either set the BOT_TOKEN environment variable on launch,
            // or put the token in `token.txt` in the working directory
            var token = Environment.GetEnvironmentVariable("BOT_TOKEN");
            if (token == null) {
                token = File.ReadAllText("token.txt");
            }

            await _interactionService.AddModuleAsync<TestModule>(null);
            _client.Ready += async () => await _interactionService.RegisterCommandsGloballyAsync();
            _client.InteractionCreated += async (x) => {
                var ctx = new SocketInteractionContext(_client, x);
                await _interactionService.ExecuteCommandAsync(ctx, null);
            };

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            Console.WriteLine("Bot is started!");

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

    }
}
