using System;

namespace DevInterviewCodeTest.Web.Helpers
{
    public class ExtensionPoint<T> where T : class
    {
        public T Target { get; }

        internal ExtensionPoint(T target)
        {
            T obj = target;
            Target = obj ?? throw new ArgumentNullException(nameof(target));
        }
    }
}
