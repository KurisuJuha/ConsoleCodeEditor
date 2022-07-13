using ConsoleCodeEditor.Plugin;

namespace TestPlugin
{
    public class Class1 : Plugin
    {
        public string data;

        public override void OnLoad()
        {
            Console.WriteLine("TestPlugin");
        }

        public override void OnReadChar(ConsoleKeyInfo c)
        {
            data += c;
            Console.Write(c);
        }
    }
}