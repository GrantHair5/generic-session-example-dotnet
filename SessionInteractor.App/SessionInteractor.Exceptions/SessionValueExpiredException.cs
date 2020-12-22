using System;

namespace SessionInteractor.Exceptions
{
    public class SessionValueExpiredException : Exception
    {
        public SessionValueExpiredException()
        {
        }

        public SessionValueExpiredException(string message)
            : base(message)
        {
        }

        public SessionValueExpiredException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}