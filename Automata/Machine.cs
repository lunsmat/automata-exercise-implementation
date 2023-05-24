namespace AutomataImplementation.Automata
{
    class Machine
    {
        public List<State> States { get; }
        public State InitialState { get; set; }
        public List<char> Alphabet { get; }
        public List<Transition> Transitions { get; }    

        public Machine(List<char> alphabet, List<State> states, State initialState, List<Transition> transitions)
        {
            States = states;
            InitialState = initialState;
            Alphabet = alphabet;
            Transitions = transitions;
        }   

        public Machine(List<char> alphabet, List<State> states, State initialState)
        {
            States = states;
            InitialState = initialState;
            Alphabet = alphabet;
            Transitions = new List<Transition>();
        }

        public bool ContainsState(string name)
        {
            foreach (var state in States)
                if (state.Name == name)
                    return true;

            return false;
        }

        public void AddState(State state)
        {
            if (ContainsState(state.Name))
                throw new Exception($"State {state.Name} already exists");

            States.Add(state);
        }

        public void AddState(string name, bool isFinal = false)
        {
            AddState(new State(name, isFinal));
        }

        public void AddState(string name, string output, bool isFinal = false)
        {
            var state = new State(name, isFinal);
            state.SetOutput(output);
            AddState(state);
        }

        public bool HasTransition(State from, State to, char symbol)
        {
            foreach (var transition in Transitions)
                if (transition.From == from && transition.To == to && transition.Symbol == symbol)
                    return true;

            return false;
        }

        public void AddTransition(Transition transition)
        {
            if (HasTransition(transition.From, transition.To, transition.Symbol))
                throw new Exception($"Transition {transition} already exists");

            Transitions.Add(transition);
        }

        public void AddTransition(State from, State to, char symbol)
        {
            Transitions.Add(new Transition(from, to, symbol));
        }

        public void AddTransition(State from, State to, char symbol, string output)
        {
            var transition = new Transition(from, to, symbol);
            transition.SetOutput(output);
            AddTransition(transition);
        }

        public void AddTransition(string from, string to, char symbol)
        {
            var fromState = States.Find(state => state.Name == from);
            var toState = States.Find(state => state.Name == to);

            if (fromState == null)
                throw new Exception($"State {from} does not exist");

            if (toState == null)
                throw new Exception($"State {to} does not exist");

            AddTransition(fromState, toState, symbol);
        }

        public void AddTransition(string from, string to, char symbol, string output)
        {
            var fromState = States.Find(state => state.Name == from);
            var toState = States.Find(state => state.Name == to);

            if (fromState == null)
                throw new Exception($"State {from} does not exist");

            if (toState == null)
                throw new Exception($"State {to} does not exist");

            AddTransition(fromState, toState, symbol, output);
        }

        public void AddVoidTransition(State from, State to)
        {
            AddTransition(from, to, '\0');
        }

        public void AddVoidTransition(State from, State to, string output)
        {
            AddTransition(from, to, '\0', output);
        }

        public void AddVoidTransition(string from, string to)
        {
            AddTransition(from, to, '\0');
        }

        public void AddVoidTransition(string from, string to, string output)
        {
            AddTransition(from, to, '\0', output);
        }

        public List<Transition> GetTransitionsFrom(State state)
        {
            var transitions = new List<Transition>();

            foreach (var transition in Transitions)
                if (transition.From == state)
                    transitions.Add(transition);

            return transitions;
        }

        public List<Transition> GetTransitionsFrom(State state, char symbol)
        {
            var transitions = new List<Transition>();

            foreach (var transition in Transitions)
                if (transition.From.Equals(state) && (transition.Symbol == symbol || transition.IsEpsilon))
                    transitions.Add(transition);

            return transitions;
        }

        public bool IsNonDeterministic()
        {
            foreach (var state in States)
            {
                var transitions = GetTransitionsFrom(state);

                foreach (var transition in transitions)
                    if (transition.IsEpsilon)
                        return true;

                if (transitions.Count > 1)
                    return true;
            }

            return false;
        }

        public bool HasEpsilonTransitions()
        {
            foreach (var state in States)
            {
                var transitions = GetTransitionsFrom(state);

                foreach (var transition in transitions)
                    if (transition.IsEpsilon)
                        return true;
            }

            return false;
        }

        private bool TransitionFunction(ref MachineResult currentResult, string input, State state, int iterator)
        {
            if (input.Length == 0 && state.IsFinal)
                return true;

            char symbol = '\0';

            if (input.Length > 0)
                symbol = input[0];

            var transitions = GetTransitionsFrom(state, symbol);

            for (int i = 0; i < transitions.Count; i++)
            {
                var transition = transitions[i];

                if (TransitionFunction(ref currentResult, input.Substring(transition.IsEpsilon ? 0 : 1), transition.To, iterator + 1))
                {
                    currentResult.AddTransition(transition);
                    return true;
                }

                currentResult.ReturnToState(iterator);
            }

            return false;
        }

        private bool TransitionFunction(ref MachineResult currentResult, string input)
        {
            var valid = TransitionFunction(ref currentResult, input, currentResult.InitialState, 0);

            currentResult.Reverse(); // Reverses the transitions to get the correct order, since the recursion goes from the end to the start

            return valid;
        }

        public MachineResult Run(string input)
        {
            var result = new MachineResult(input, InitialState);

            bool inputInLanguage = TransitionFunction(ref result, input);

            return result;
        }

        public override string ToString()
        {
            string output = "";

            output += "Alphabet: ";
            foreach (var symbol in Alphabet)
                output += symbol + " ";

            output += "\nInitial State: " + InitialState + "\n";

            output += "States: ";
            foreach (var state in States)
                output += state + " ";

            output += "\nFinal States: ";
            foreach (var state in States)
                if (state.IsFinal)
                    output += state + " ";

            output += "\nTransitions:\n";
            foreach (var transition in Transitions)
                output += transition + "\n";
                
            return output;            
        }
    }
}
