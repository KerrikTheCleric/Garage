using Garage.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage {
    internal static class Helper {

        /// <summary>
        /// Checks if a registration number keeps to the valid standard of 3 letters and 3 numers, like ABC123.
        /// </summary>
        /// <param name="regNumber">The registration number to check.</param>
        /// <returns>True if valid, false otherwise.</returns>

        public static bool IsRegistrationNumberValid(string regNumber) {
            if (regNumber.Length != 6) {
                return false;
            }

            for (int i = 0; i < 6; i++) {
                if (i < 3) {
                    if (!char.IsLetter(regNumber[i])) { return false; }
                } else {
                    if (!char.IsNumber(regNumber[i])) { return false; }
                }
            }
            return true;
        }
    }
}
