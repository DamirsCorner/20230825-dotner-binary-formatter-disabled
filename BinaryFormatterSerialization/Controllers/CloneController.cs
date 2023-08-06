using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryFormatterSerialization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CloneController : ControllerBase
    {
        [HttpPost]
        public Person Post(Person person)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Serialize the object into the memory stream.
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, person);

                // Rewind the stream and use it to create a new object.
                memoryStream.Position = 0;
                return (Person)formatter.Deserialize(memoryStream);
            }
        }
    }
}
