using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Errors {
    internal class NoFilterSelectedError : UserError {
        public override string UEMessage() {
            return "Please select a valid filter.";
        }
    }
}
