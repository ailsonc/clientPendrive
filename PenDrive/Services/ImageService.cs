using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PenDrive.model
{
    class ImagenService
    {
        public const string URL = "https://run.mocky.io/v3/b34b8b64-efce-4933-8157-834ec89b2d2e";

        /*
          {
              "images": [
                { "image":"Linux1", "path": "c:\test"},
                { "image":"Linux2", "path": "c:\test2"}
              ]
            }
        */
        public static async Task<string> getImagens()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(URL);
                var contents = await response.Content.ReadAsStringAsync();
                return contents;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
