namespace Vertica.UCommerce.Utilities.Infrastructure
{
    public struct Iteration<T>
    {
        public Iteration(int number, T context)
            : this()
        {
            Number = number;
            Context = context;
        }

        public int Number { get; private set; }
        public T Context { get; private set; }
    }
}