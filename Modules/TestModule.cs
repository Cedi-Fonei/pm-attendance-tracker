using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Attendance_Tracker.Modules
{
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
}
