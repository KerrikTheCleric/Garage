using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Enums;

namespace Garage.Interfaces
{
    public interface IVehicle
    {

        public string GetRegistrationNumber();

        public Colour GetColour();

        public double GetCargoSpace();

        public double GetWeight();

        public int GetTopSpeed();

        public int GetWheels();

        public string GetSpecificationsText();
    }
}
