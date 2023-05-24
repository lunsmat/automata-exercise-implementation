using AutomataImplementation.QuestionOne;

namespace AutomataImplementation
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Count() == 0)
            {
                Console.WriteLine("No args found!");
                return;
            }

            IQuestion implemented;   

            switch (args[0])
            {
                case "q1.a":
                    implemented = new A();
                    break;
                case "q1.b":
                    implemented = new B();
                    break;
                case "q1.c":
                    implemented = new C();
                    break;
                case "q1.d":
                    implemented = new D();
                    break;
                case "q3":
                    implemented = new QuestionThree();
                    break;
                default:
                    Console.WriteLine($"Not found command {args[0]}");
                    return;
            }

            implemented.Run(args.Skip(1).ToArray());
            return;
        }
    }
}
