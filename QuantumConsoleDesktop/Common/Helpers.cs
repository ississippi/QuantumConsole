using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace QuantumConsoleDesktop.Common
{
    public static class Helpers
    {
        private const string resxFile = @".\QuantumConsoleResources.resx";
        public static string GetResourceString(string key)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                // Retrieve the string resource for the title.
                var s = resxSet.GetString(key);
                return s;
            }
        }
    }
}
