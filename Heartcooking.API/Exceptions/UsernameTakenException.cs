using System;

namespace Heartcooking.API.Exceptions
{
    public class UsernameTakenException : Exception
    {

        public UsernameTakenException() :base("This username has been taken.")
        {
        }

        public UsernameTakenException(string message)
            : base(message)
        {
        }

        public UsernameTakenException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}