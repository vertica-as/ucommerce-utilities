namespace Vertica.UCommerce.Utilities.Testing
{
    public abstract class Builder<T>
    {
        public static implicit operator T(Builder<T> builder)
        {
            if (builder == null)
                return default(T);

            return builder.Build();
        }

        public abstract T Build();
    }
}