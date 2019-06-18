/* Discord Namespaces */
using DSharpPlus;
using DSharpPlus.CommandsNext;
/* .NET Namespaces */
using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
/* JSON Namespaces */
using Newtonsoft.Json;
using System.Linq;

namespace SelfBot_Framework.Startup
{
    public class Config
    {
        public static void ConfigSetup()
        {
            try
            {
                if (!File.Exists("config.json"))
                {
                    ConfigJson configJson = new ConfigJson
                    {
                        token = ""
                    };
                    string serializedJson = JsonConvert.SerializeObject(configJson, Formatting.Indented);
                    File.WriteAllText("config.json", serializedJson);
                    Console.WriteLine("Your config has been generated please enter your token and restart the bot...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                string json = "";
                using (var fs = File.OpenRead("config.json"))
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = sr.ReadToEnd();
                }
                var cfgJson = JsonConvert.DeserializeObject<ConfigJson>(json);
                Startup.token = cfgJson.token;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

    }
    public class ConfigJson
    {
        public string token { get; set; }
    }
}
