using AutomataImplementation.Automata;

namespace AutomataImplementation
{
    class QuestionTwo: IQuestion
    {
        public Machine Automata;

        public QuestionTwo()
        {
            State initialState = new State("0", true);
            var alphabet = new List<char> { 'a', 'b', 'c' };
            var states = new List<State> { initialState };

            Automata = new Machine(alphabet, states, initialState);

            Automata.AddState("25", true);
            Automata.AddState("50", true);
            Automata.AddState("75", true);

            Automata.AddTransition("0", "25", 'a', "0");
            Automata.AddTransition("0", "50", 'b', "0");
            Automata.AddTransition("0", "0", 'c', "1");

            Automata.AddTransition("25", "50", 'a', "0");
            Automata.AddTransition("25", "75", 'b', "0");
            Automata.AddTransition("25", "25", 'c', "1");

            Automata.AddTransition("50", "75", 'a', "0");
            Automata.AddTransition("50", "0", 'b', "1");
            Automata.AddTransition("50", "50", 'c', "1");

            Automata.AddTransition("75", "0", 'a', "1");
            Automata.AddTransition("75", "25", 'b', "1");
            Automata.AddTransition("75", "75", 'b', "1");
        }

        Machine IQuestion.Automata => throw new NotImplementedException();

        public void Run(string[] args)
        {
            try {
                foreach (var input in args) {
                    Console.Write(Automata);
                    Console.WriteLine("----------------------Divider Response--------------------------");
                    Console.Write(Automata.Run(input));
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine();
                }
            } catch (Exception error) {
                Console.WriteLine(error.Message);
            }
        }
    }
}
