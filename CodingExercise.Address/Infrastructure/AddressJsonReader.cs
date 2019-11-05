using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CodingExercise.Address.Infrastructure
{
    public class AddressJsonReader
    {
        public static List<Model.Address> ReadJsonAddress(string  FileLocation)
        {
            var addresses = new List<Model.Address>();
            JArray filearray = JArray.Parse(File.ReadAllText(FileLocation));
            for (int i = 0; i < filearray.Count; i++)
            {
                addresses.Add(filearray[i].ToObject<Model.Address>());
            }
            return addresses;

        }
    }
}
