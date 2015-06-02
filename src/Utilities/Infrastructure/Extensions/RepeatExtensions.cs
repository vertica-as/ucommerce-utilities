using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vertica.UCommerce.Utilities.Infrastructure.Extensions
{
    public static class RepeatExtensions
    {
        public static Repeat Repeat(this uint times)
        {
            return Infrastructure.Repeat.Times(times);
        }

        public static IEnumerable<Iteration<T>> Repeat<T>(this uint times, T context)
        {
            return Repeat(times).Select(iteration => new Iteration<T>(iteration, context));
        }
    }
}