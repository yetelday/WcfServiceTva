using System;

namespace BricachocBo.Exceptions.FamilleExceptions
{
    public class NotExistFamilleException :ApplicationBricachocException
    {
        public NotExistFamilleException()
        {
        }
        public NotExistFamilleException(string message): base(message)
        {
        }
        public NotExistFamilleException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
