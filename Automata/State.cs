namespace AutomataImplementation.Automata
{
    class State
    {
        public string Name { get; }
        public bool IsFinal { get; }

        public string? Output; // To be used in Moore machines

        public State(string name, bool isFinal = false)
        {
            Name = name;
            IsFinal = isFinal;
        }

        public void SetOutput(string output)
        {
            Output = output;
        }

        public string GetOutput()
        {
            return Output ?? "";
        }

        public bool Equals(State state)
        {
            return Name == state.Name && IsFinal == state.IsFinal;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
