using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Errors {
    internal class GarageFullError : UserError {
        public override string UEMessage() {
            return "The garage is full. No new vehicles can be added until existing ones are removed.";
        }
    }
}
