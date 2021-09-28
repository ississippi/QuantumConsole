using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

using QuantumEncryptModels;

namespace QuantumConsoleDesktop.Common
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonSerializer.Serialize<T>(self);
            return JsonSerializer.Deserialize<T>(serialized);
        }
    }
}
