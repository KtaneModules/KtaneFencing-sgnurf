using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class ListExtensions
    {
        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            int index = -1;
            foreach (TSource element in source)
            {
                index = checked(index + 1);
                if (predicate(element, index))
                {
                    return element;
                }
            }

            throw new InvalidOperationException("No match");
        }
    }
}