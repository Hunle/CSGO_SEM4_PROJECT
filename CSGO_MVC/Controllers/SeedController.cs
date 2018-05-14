using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Models;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CSGO_MVC.Controllers
{
    public sealed partial class SeedController
    {

        const string URL = "https://www.fourmilab.ch/cgi-bin/Hotbits.api?nbytes=50&fmt=xml&npass=1&lpass=8&pwtype=3&apikey=HB1bnGVyQmCsrTj8GYd7CDaWQX0";
        static HttpClient client = new HttpClient();
        public int[] Numberseed { get; set; }
        static void Main(string[] args)
        {
            //RunAsync().Wait();
        }
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

        public void GetNumberAsync()
        {
            XDocument doc = XDocument.Load(URL);

            string randomNumbers = (string)doc.Descendants("random-data").FirstOrDefault();

            Numberseed = randomNumbers.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x, System.Globalization.NumberStyles.HexNumber)).ToArray();

            Console.WriteLine(string.Join(",", Numberseed.Select(x => x.ToString())));
            Console.ReadLine();
            
        }

    }






    }
