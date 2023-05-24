using AutomataImplementation.Automata;

namespace AutomataImplementation
{
    interface IQuestion {
        public Machine Automata { get; }
        public void Run(string[] args);
    }
}
