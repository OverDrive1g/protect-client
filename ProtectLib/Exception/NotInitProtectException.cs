namespace ProtectLib.Exception
{
    public class NotInitProtectException:System.Exception
    {
        public NotInitProtectException()
        {
        }

        public NotInitProtectException(string message) : base(message)
        {
        }
    }
}