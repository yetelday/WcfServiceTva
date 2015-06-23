using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocBo.Exceptions.ProduitExceptions
{
    public class ArticleGenericException : ProduitException
    {

        public ArticleGenericException()
        {
        }
        public ArticleGenericException(string message): base(message)
        {
        }
        public ArticleGenericException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
