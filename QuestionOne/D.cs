using AutomataImplementation.Automata;

namespace AutomataImplementation.QuestionOne
{
    class D: IQuestion
    {
        public Machine Automata;

        public D()
        {
            State initialState = new State("q0");
            var alphabet = new List<char> { 'a', 'b', 'c' };
            var states = new List<State> { initialState };

            Automata = new Machine(alphabet, states, initialState);

            Automata.AddState("q1", true);
            Automata.AddState("q2");
            Automata.AddState("q3", true);
            Automata.AddState("q4", true);  

            Automata.AddTransition("q0", "q1", 'a');
            Automata.AddTransition("q0", "q2", 'b');
            Automata.AddTransition("q1", "q1", 'a');
            Automata.AddTransition("q1", "q2", 'b');
            Automata.AddTransition("q2", "q2", 'b');
            Automata.AddTransition("q2", "q3", 'a');
            Automata.AddTransition("q1", "q4", 'c');
            Automata.AddTransition("q3", "q4", 'c');
            Automata.AddTransition("q4", "q4", 'c');
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
