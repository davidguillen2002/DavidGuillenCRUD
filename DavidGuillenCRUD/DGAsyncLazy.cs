using System.Runtime.CompilerServices;

namespace DavidGuillenCRUD
{
    public class DGAsyncLazy<T>
    {
        readonly Lazy<Task<T>> instance;

        public DGAsyncLazy(Func<T> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public DGAsyncLazy(Func<Task<T>> factory) {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }
         
        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }

        public void Start()
        {
            var unused = instance.Value;
        }
    }
}
