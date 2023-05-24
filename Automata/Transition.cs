namespace AutomataImplementation.Automata
{
    class Transition
    {
        public State From { get; }
        public State To { get; }
        public char Symbol { get; }
        public bool IsEpsilon => Symbol == '\0';

        public string? Output; // To be used in Mealy machines

        public Transition(State from, State to, char symbol)
        {
            From = from;
            To = to;
            Symbol = symbol;
        }

        public void SetOutput(string output)
        {
            Output = output;
        }

        public string GetOutput()
        {
            return Output ?? "";
        }

        public override string ToString()
        {
            return $"{From} --{Symbol}/{GetOutput()}--> {To}";
        }
    }
}
