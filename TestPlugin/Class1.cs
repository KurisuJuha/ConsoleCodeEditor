using ConsoleCodeEditor.Plugin;

namespace TestPlugin
{
    public class Class1 : Plugin
    {
        public override void OnLoad()
        {
            Console.WriteLine("TestPlugin");
        }
    }
}