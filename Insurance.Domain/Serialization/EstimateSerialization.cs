using Insurance.Domain.Models;
using System.IO;
using System.Xml.Serialization;

namespace Insurance.Domain.Serialization
{
    public class EstimateSerialization
    {
        public EstimateSerialization()
        {
            Estimates = null;
        }

        [XmlArray]
        public Estimate[] Estimates { get; set; }


        public static EstimateSerialization FromXmlString(string xmlString)
        {
            var reader = new StringReader(xmlString);
            var serializer = new XmlSerializer(typeof(EstimateSerialization));
            var instance = (EstimateSerialization)serializer.Deserialize(reader);

            return instance;
        }
    }
}
