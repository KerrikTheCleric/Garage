using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Errors {
    internal class ExistingRegistrationNumberError : UserError {
        public override string UEMessage() {
            return "Registration number already exists in the garage. The inputted vehicle cannot be added.";
        }
    }
}
