using System;

namespace Business.CustomErrors
{
    public class ClientException : Exception
    {
        public ClientException(string message) : base(message)
        {

        }
    }
}
