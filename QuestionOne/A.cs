using AutomataImplementation.Automata;

namespace AutomataImplementation.QuestionOne
{
    class A: IQuestion
    {
        public Machine Automata;

        public A()
        {
            State initialState = new State("q0", true);
            var alphabet = new List<char> { 'a', 'b', 'c' };
            var states = new List<State> { initialState };

            Automata = new Machine(alphabet, states, initialState);

            Automata.AddState("q1", true);
            Automata.AddState("q2", true);

            Automata.AddTransition("q0", "q0", 'a');
            Automata.AddTransition("q0", "q1", 'b');
            Automata.AddTransition("q0", "q2", 'c');
            Automata.AddTransition("q1", "q0", 'a');
            Automata.AddTransition("q1", "q1", 'b');
            Automata.AddTransition("q1", "q2", 'c');
            Automata.AddTransition("q2", "q0", 'a');
            Automata.AddTransition("q2", "q2", 'c');
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
