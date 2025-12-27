namespace ECommerce.Application.Bases
{
    public abstract class BaseException : ApplicationException
    {
        public BaseException() { }
       
        public BaseException(string message) : base(message) { }

    }
}
