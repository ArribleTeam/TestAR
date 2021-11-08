namespace CoroutineHandler
{
    public interface ICoroutine
    {
        void Start();
        void Stop();
    }
    public interface ICoroutine<T>
    {
        void Start(T arg);
        void Stop();
    }
    public interface ICoroutine<T, R>
    {
        void Start(T arg1, R arg2);
        void Stop();
    }
}
