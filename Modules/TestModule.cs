using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;

namespace Attendance_Tracker.Modules
{
    public class TestModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("ping", "A test ping.")]
        public async Task Ping()
        {
            await RespondAsync("Pong!");
        }
    }
}
