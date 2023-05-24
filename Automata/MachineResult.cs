namespace AutomataImplementation.Automata
{
    class MachineResult
    {
        public string Input;
        public State InitialState  { get; }
        public List<Transition> Transitions;

        public MachineResult(string input, State initialState)
        {
            Input = input;
            InitialState = initialState;
            Transitions = new List<Transition>();
        }

        public State GetLastState()
        {
            if (Transitions.Count == 0)
                return InitialState;

            return Transitions[Transitions.Count - 1].To;
        }

        public string GetMooreOutput()
        {
            string output = InitialState.GetOutput();

            foreach (var transition in Transitions)
                output += transition.To.GetOutput();

            return output;
        }

        public string GetMealyOutput()
        {
            string output = "";

            foreach (var transition in Transitions)
                output += transition.GetOutput();

            return output;
        }

        public bool VerifyTransitions()
        {
            State currentState = InitialState;
            string input = Input;

            foreach (var transition in Transitions)
            {
                if (!currentState.Equals(transition.From))
                    return false;

                if (!transition.IsEpsilon && transition.Symbol != input[0])
                    return false;

                currentState = transition.To;
                input = input.Substring(transition.IsEpsilon ? 0 : 1);
            }

            if (input.Length > 0)
                return false;

            return true;
        }

        public bool GetIsAccepted()
        {
            return GetLastState().IsFinal && VerifyTransitions();
        }

        public void AddTransition(Transition transition)
        {
            Transitions.Add(transition);
        }

        public void ReturnToState(int state)
        {
            Transitions.RemoveRange(state, Transitions.Count - state);
        }
        
        public void Reverse()
        {
            Transitions.Reverse();
        }

        public override string ToString()
        {
            string output = $"Input: {Input}\n";
            output += $"Initial State: {InitialState}\n";
            output += $"Final State: {GetLastState()}\n";
            output += $"Is Accepted: {GetIsAccepted()}\n";
            output += $"Melay Output: {GetMealyOutput()}\n";
            output += $"Moore Output: {GetMooreOutput()}\n";
            output += $"Transitions:\n";

            foreach (var transition in Transitions)
                output += $"  {transition}\n";

            return output;
        }
    }
}
