namespace ECommerce.Application.Bases
{
    public abstract class BaseExceptions : ApplicationException
    {
        public BaseExceptions() { }
       
        public BaseExceptions(string message) : base(message) { }

    }
}
