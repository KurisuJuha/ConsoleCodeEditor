using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleCodeEditor.Plugin
{
    public static class PluginLoader
    {
        public static List<Plugin> Plugins = new List<Plugin>();

        public static void LoadPlugin()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Plugins");
            Console.WriteLine(path);
            LoadPlugin(path);
        }

        public static void LoadPlugin(string name)
        {
            List<string> PluginPath = new List<string>(0);
            using (StreamReader sr = new StreamReader("Plugins.cce",Encoding.UTF8))
            {
                string PluginData = sr.ReadToEnd();
                PluginPath.AddRange(PluginData.Split('\n'));
            }

            PluginPath.AddRange(Directory.GetFiles(name));

            //EXEの場所にあるDLLファイルをすべて読み込む
            foreach (string dll in PluginPath)
            {
                //DLLファイル以外は読まない
                if (dll.ToLower().EndsWith(".dll") == false) continue;

                //存在しないなら読み込みしない
                if (!File.Exists(dll)) continue;

                //ファイル読み込み
                var asm = Assembly.LoadFrom(dll);

                //DLLの中のTypeをすべて取得し、プラグインのタイプがあるかチェックする
                foreach (Type type in asm.GetTypes())
                {
                    //プラグインかどうかは継承元がプラグインベースになっているか
                    if (type.BaseType != typeof(Plugin)) continue;

                    //対象のクラスのインスタンスを作成
                    Plugin plugin = (Plugin)Activator.CreateInstance(type);

                    Plugins.Add(plugin);
                }
            }
        }
    }
}
