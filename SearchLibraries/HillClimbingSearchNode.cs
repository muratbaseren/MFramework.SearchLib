namespace MFramework.SearchLib
{
    public class HillClimbingSearchNode<T>
    {
        public T State { get; private set; }
        public double HeuristicValue { get; private set; }

        public HillClimbingSearchNode(T state, double heuristicValue)
        {
            State = state;
            HeuristicValue = heuristicValue;
        }

        public override string ToString()
        {
            return State.ToString();
        }
    }
}