namespace Tahseen.Service.Exceptions
{
    public class TahseenException : Exception
    {
        int statusCode;
        public TahseenException(int code, string message) : base(message) 
        {
            this.statusCode = code;
        }
    }
}
