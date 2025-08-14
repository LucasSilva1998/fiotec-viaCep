using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fiotec_viaCep.Application.Exceptions
{
    public class ParametroInvalidoException : Exception
    {
        public ParametroInvalidoException(string message) : base(message) { }
    }
}