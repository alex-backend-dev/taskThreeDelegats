using System;
using System.Threading;

namespace taskThreeDelegates
{
    class Program
    {
        const int EVENTCOUNTER = 10;
        static void Main(string[] args)
        {
            EventGenerator generator = new EventGenerator();
            generator.GeneratorEvent += new EventHandler(generator_GeneratorEvent);
            generator.StartGenerate();
            Console.ReadLine();
        }

        static void generator_GeneratorEvent(object sender, EventArgs e)
        {
            EventGenerator g = sender as EventGenerator;
            if (g != null & g.GenerationCount == 0)
            {
                g.GenerationCount = EVENTCOUNTER;
            }
            Console.WriteLine("Got Event!");
        }
    }
    
    public class EventGenerator
    {
        public event EventHandler GeneratorEvent = delegate { };
        public int GenerationCount { get; set; }
        public void StartGenerate()
        {
            do
            {
                GeneratorEvent(this, EventArgs.Empty);
                if (GenerationCount > 0)
                {
                    GenerationCount -= 1;
                }
                Thread.Sleep(1000);
            }
            while (GenerationCount != 0);
        }
    }
}
