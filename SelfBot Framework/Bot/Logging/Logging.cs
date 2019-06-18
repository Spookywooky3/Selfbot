using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;

namespace SelfBot_Framework.Logging
{
    public class Logging
    {
        /* EVENT LOGGING */
        public static Task CommandErrored(CommandErrorEventArgs e)
        {
            Error($"{e.Context.User.Username} failed to execute: {e.Command?.QualifiedName ?? "Unknown command"} and recieved error: {e.Exception.Message ?? "No message"}");
            return Task.CompletedTask;
        }
        public static Task CommandExecuted(CommandExecutionEventArgs e)
        {
            Beautify($"{e.Context.User.Username} successfully executed: {e.Command.QualifiedName}");
            return Task.CompletedTask;
        }
        public static Task MessageRecieved(MessageCreateEventArgs e)
        {
            /* AUTHOR CHECK */
            if (!e.Author.IsBot && e.Author != e.Client.CurrentUser)
            {
                /* MESSAGE TYPE CHECK */
                if (e.Message.MessageType == MessageType.Default)
                {
                    /* OUTPUT TO CONSOLE AND MAKE IT LOOK FANCY */
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"[{DateTime.Now}] ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{e.Message.Author.Username}#{e.Message.Author.Discriminator} | ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{e.Message.Content}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" | #{e.Message.Channel.Name} {e.Guild.Name}" + Environment.NewLine);
                    Console.ResetColor();
                }
            }
            return Task.CompletedTask;
        }
        public static Task HeartBeatRecieved(HeartbeatEventArgs e)
        {
            Beautify($"Heartbeat recieved: {e.Ping}ms");
            return Task.CompletedTask;
        }

        /* MAKE IT LOOK FANCY ( ´◔ ω◔`) ノシ */
        public static Task Beautify(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now}] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message + Environment.NewLine);
            return Task.CompletedTask;
        }
        public static Task Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[{DateTime.Now}] ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message + Environment.NewLine);
            return Task.CompletedTask;
        }
    }
}
