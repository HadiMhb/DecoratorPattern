namespace Decorator_Pattern_Advance.Interfaces
{
    public interface IPolicy
    {
        public T Invoke<T>(Func<T> func);
    }
}
