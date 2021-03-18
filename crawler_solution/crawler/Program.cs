using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace crawler
{
    class Program : IDisposable
    {
        void IDisposable.Dispose() { }
        public void Dispose() { }

        static async Task Main(string[] args)
        {
            var url = args.Length > 0 ? args[0] : throw new ArgumentNullException("No http passed");
            if (!(Uri.IsWellFormedUriString(url, UriKind.Absolute)))
            {
                throw new ArgumentException("Given string not a valid url");
            }
            var client = new HttpClient();
            HttpResponseMessage result = await client.GetAsync(url);
            if (result.IsSuccessStatusCode)
            {

                //await means that it will wait till we get string 
                string htmlContent = await result.Content.ReadAsStringAsync();
                StringReader reader = new StringReader(htmlContent);
                using (reader)
                {
                    var regex = new Regex(@"[\w]+@[\w]+(\.[\w]{2,10}\b)+", RegexOptions.IgnoreCase);
                    //regex to find all @ mails in HTML content of site
                    if (regex.IsMatch(htmlContent))
                    {
                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("E-mail addresses not found");
                    }
                }
                // above code disposing the resourse of htmlContent
                

               

                Console.WriteLine("request successful");

            }   
            else
            {
                Console.WriteLine("Error while downloading");
            }
        }
    }
}
