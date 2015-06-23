using System;
using BricachocBo.Exceptions.TvaExceptions;

namespace BricachocBo.Exceptions.TvaExceptions
{
    public class NotExistTvaException : TvaException
    {
        public NotExistTvaException()
        {
        }
        public NotExistTvaException(string message): base(message)
        {
        }
        public NotExistTvaException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
