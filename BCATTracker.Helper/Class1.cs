using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCATTracker.Helper
{
    public class Class1
    {

        private T Deserialize<T>(string responseBody)
        {
            var toReturn = JsonConvert.DeserializeObject<T>(responseBody); // json _jsonConverter.DeserializeObject<T>(responseBody);
            return toReturn;
        }
    }
}
