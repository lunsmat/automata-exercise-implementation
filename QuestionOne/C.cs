using AutomataImplementation.Automata;

namespace AutomataImplementation.QuestionOne
{
    class C: IQuestion
    {
        public Machine Automata;

        public C()
        {
            State initialState = new State("q0");
            var alphabet = new List<char> { 'a', 'b', 'c' };
            var states = new List<State> { initialState };

            Automata = new Machine(alphabet, states, initialState);

            Automata.AddState("q1", true);
            Automata.AddState("q2", true);
            Automata.AddState("q3", true);
            Automata.AddState("q4");
            Automata.AddState("q5", true);  

            Automata.AddTransition("q0", "q1", 'b');
            Automata.AddTransition("q0", "q2", 'a');
            Automata.AddTransition("q2", "q3", 'b');
            Automata.AddTransition("q3", "q3", 'b');
            Automata.AddTransition("q2", "q4", 'a');
            Automata.AddTransition("q4", "q4", 'a');
            Automata.AddTransition("q4", "q5", 'b');
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
