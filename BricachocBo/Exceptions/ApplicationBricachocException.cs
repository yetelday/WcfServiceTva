using System;

namespace BricachocBo.Exceptions
{
    public class ApplicationBricachocException : System.Exception
    {
         public ApplicationBricachocException()
        {
        }
        public ApplicationBricachocException(string message): base(message)
        {
        }
        public ApplicationBricachocException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
