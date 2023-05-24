using AutomataImplementation.Automata;

namespace AutomataImplementation.QuestionOne
{
    class B: IQuestion
    {
        public Machine Automata;

        public B()
        {
            State initialState = new State("q0");
            var alphabet = new List<char> { 'a', 'b', 'c' };
            var states = new List<State> { initialState };

            Automata = new Machine(alphabet, states, initialState);

            Automata.AddState("q1");
            Automata.AddState("q2");
            Automata.AddState("q3");
            Automata.AddState("q4", true);
            Automata.AddState("q5", true);
            Automata.AddState("q6");
            Automata.AddState("q7");
            Automata.AddState("q8", true);

            Automata.AddTransition("q0", "q2", 'a');
            Automata.AddTransition("q2", "q3", 'a');
            Automata.AddTransition("q3", "q4", 'a');
            Automata.AddTransition("q4", "q5", 'b');
            Automata.AddTransition("q4", "q5", 'c');
            Automata.AddTransition("q5", "q5", 'b');
            Automata.AddTransition("q5", "q5", 'c');

            Automata.AddTransition("q0", "q1", 'b');
            Automata.AddTransition("q0", "q1", 'c');
            Automata.AddTransition("q1", "q1", 'b');
            Automata.AddTransition("q1", "q1", 'c');
            Automata.AddTransition("q1", "q6", 'a');
            Automata.AddTransition("q6", "q7", 'a');
            Automata.AddTransition("q7", "q8", 'a');
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
