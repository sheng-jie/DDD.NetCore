namespace DDD.NetCore.Exception
{
    public class ExceptionBase : System.Exception
    {
        public ExceptionBase()
        {
        }

        public ExceptionBase(string message) : base(message)
        {
        }

        public ExceptionBase(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}