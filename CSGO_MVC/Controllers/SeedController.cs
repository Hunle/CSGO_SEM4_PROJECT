using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web.Mvc;


namespace CSGO_MVC.Controllers
{
    public sealed partial class SeedController
    {

        const string URL = "https://www.fourmilab.ch/cgi-bin/Hotbits.api?nbytes=50&fmt=xml&npass=1&lpass=8&pwtype=3&apikey=&pseudo=pseudo";
        static HttpClient client = new HttpClient();
        public static int[] Numberseed { get; set; }

        //static async Task<string> GetProductAsync(string path = "")
        //{
        //    string RNGSeed = string.Empty;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        RNGSeed = await response.Content.ReadAsStringAsync();
        //    }
        //    return RNGSeed;
        //}
        //static async Task RunAsync()
        //{
        //    string str = await GetProductAsync();
        //    XmlDocument xml = new XmlDocument();
        //    xml.Load(str);
        //    Console.WriteLine(xml.InnerXml);
        //    XmlNodeList list = xml.GetElementsByTagName("random-data");
        //    string[] strs = list[0].InnerXml.Split(' ');
        //    foreach (object e in strs)
        //    {
        //        Console.WriteLine(e);
        //    }

        public IEnumerable<int> GetNumber()
        {
            XDocument doc = XDocument.Load(URL);

            string randomNumbers = (string)doc.Descendants("random-data").FirstOrDefault();

            Numberseed = randomNumbers.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber)).ToArray();
            return Numberseed;

        }






    }
}

