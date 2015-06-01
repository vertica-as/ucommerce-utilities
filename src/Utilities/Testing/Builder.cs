using System;

namespace Vertica.UCommerce.Utilities.Testing
{
    public abstract class Builder<T> where T : class
    {
        protected readonly T Instance;

        protected Builder(T instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");

            Instance = instance;
        }

        public static implicit operator T(Builder<T> builder)
        {
            if (builder == null)
                return default(T);

            return builder.Build();
        }

        public virtual T Build()
        {
            return Instance;
        }
    }
}