using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Errors
{
    internal class RegistratíonNumberFormatError : UserError
    {

        public override string UEMessage()
        {
            return "Registration number must be 6 characters long, consist of 3 letters & 3 numbers and be formatted like ABC123.";
        }
    }
}
