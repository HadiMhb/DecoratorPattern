using Decorator_Pattern_Advance.Interfaces;

namespace Decorator_Pattern_Advance.Policies
{
    public class ReportExceptionPolicy : IPolicy
    {
        public T Invoke<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                //TODO: Log exception detail
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
