using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Attendance_Tracker.Modules
{
    [Group("audit")]
    public class AuditModule : ModuleBase<SocketCommandContext>
    {
        [Command("list")]
        [Summary("!TBD! Lists the names of all members in good standing")]
        public async Task ListAsync()
        {
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }

        [Command("self")]
        [Summary("!TBD! Displays whether or not the user who ran this command is in good standing")]
        public async Task AuditSelfAsync()
        {
            await Context.Channel.SendMessageAsync("This function is still TBD! No functionality yet!");
        }
    }
}
