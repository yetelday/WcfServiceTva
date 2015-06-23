﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BricachocDal.Exceptions
{
    public class DaoExceptionFinAppli: DaoException
    {
        public DaoExceptionFinAppli(): base()
        {
        }

        public DaoExceptionFinAppli(string message)
            : base(message)
        {
        }
        public DaoExceptionFinAppli(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}
