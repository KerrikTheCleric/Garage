using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Interfaces {
    internal interface IUI {

        public void DisplayError(string error);

        public int AskGarageSize();
    }
}
