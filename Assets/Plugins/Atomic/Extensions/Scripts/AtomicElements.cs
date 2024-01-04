using System;
using Atomic.Elements;

namespace Atomic.Extensions
{
    public static class AtomicElementsExtensions
    {
        public static AtomicValue<T> AsValue<T>(this T it)
        {
            return new AtomicValue<T>(it);
        }

        public static AtomicVariable<T> AsVariable<T>(this T it)
        {
            return new AtomicVariable<T>(it);
        }

        public static AtomicFunction<R> AsFunction<T, R>(this T it, Func<T, R> func)
        {
            return new AtomicFunction<R>(() => func.Invoke(it));
        }
    }
}