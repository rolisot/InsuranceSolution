using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;

namespace Insurance.Common.Helper
{
    public class GoogleMaps
    {
        public const string URL = "http://maps.googleapis.com/maps/api/geocode/json?address=";


        public static Geolocation GetCoordinatesByAddress(string address)
        {
            Stream stream = GetResponseStream(address);
            string content;

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
               content = reader.ReadToEnd();
            }

            GoogleGeoCodeResponse test = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(content);
            location location = (test.results[0].geometry).location;
            return new Geolocation(location);
        }

        public static Stream GetResponseStream(string address)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(URL + address);
            wr.Timeout = 50000;//5 segundos
            WebResponse resp = wr.GetResponse();
            return resp.GetResponseStream();
        }

    }
}
