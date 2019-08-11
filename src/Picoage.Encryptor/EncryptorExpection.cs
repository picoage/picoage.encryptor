using System;

namespace Picoage.Encryptor
{
    public class EncryptorExpection : Exception
    {
        private static readonly string DefaultMessage = "An error has accurred!" ; 
        public EncryptorExpection(): base(DefaultMessage)
        {

        }

        public EncryptorExpection(string message): base(message)
        {

        }

        public EncryptorExpection(Exception exception) : base(DefaultMessage, exception)
        {

        }

        public EncryptorExpection(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
