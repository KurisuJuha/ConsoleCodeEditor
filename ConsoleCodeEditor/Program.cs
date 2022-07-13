using Kokuban;
using ConsoleCodeEditor.Plugin;

namespace ConsoleCodeEditor
{
    public class ConsoleCodeEditor
    {
        public static void Main(string[] args)
        {
            PluginLoader.LoadPlugin();

            foreach (var plugin in PluginLoader.Plugins)
            {
                plugin.OnLoad();
            }

            Console.Clear();

            while (true)
            {
                ConsoleKeyInfo c = Console.ReadKey(true);

                foreach (var plugin in PluginLoader.Plugins)
                {
                    plugin.OnReadChar(c);
                }
            }
        }
    }
}