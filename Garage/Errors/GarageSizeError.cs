using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Errors {
    internal class GarageSizeError : UserError {
        public override string UEMessage() {
            return "No valid number provided. A garage must at least house a single vehicle.";
        }
    }
}
