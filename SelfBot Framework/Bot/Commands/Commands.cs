using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SelfBot_Framework.Commands
{
    public class Commands
    {
        [Command("HelloWorld"), Description("A simple test command")]
        public async Task HelloWorld(CommandContext ctx)
        {
            await ctx.Message.DeleteAsync();
            await ctx.RespondAsync("Hello World!");
        }
    }
}
