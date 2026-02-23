using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Attendance_Tracker.Modules
{
    [Group("recording")]
    public class RecordingModule : ModuleBase<SocketCommandContext>
    {
        [Command("start")] //!recording start
        [Summary("!TBD! Starts tracking attendance for the current meeting.")]
        public async Task StartAsync()
        {
            Console.WriteLine("Attempting to START recording...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }

        [Command("stop")] //!recording stop
        [Summary("!TBD! Stops tracking attendance for the current meeting.")]
        public async Task EndAsync()
        {
            Console.WriteLine("Attempting to STOP recording...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }

        [Command("members")] //!recording members
        [Summary("!TBD! Lists the names of all members attending the current meeting.")]
        public async Task ListMembersAsync()
        {
            Console.WriteLine("Attempting to list today's members...");
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }
    }
}
