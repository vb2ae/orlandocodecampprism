using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrlandoDemo.Services
{
    public class LaunchService: IGetLaunches
    {
        public LaunchService()
        {
        }

        public async Task<Models.Welcome> GetLaunches()
        {
            HttpClient http = new HttpClient();
            string json=string.Empty;
            string fileName = "launches.json";
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
           try
            {
                json= await http.GetStringAsync("https://www.nasa.gov/api/2/calendar-event/_search?size=100&from=0&sort=event-date.value&q=(((calendar-name%3A6089)%20AND%20(event-date.value%3A%5B2018-03-06T20%3A44%3A51-05%3A00%20TO%202028-03-06T20%3A44%3A51-05%3A00%5D%20OR%20event-date.value2%3A%5B2018-03-06T20%3A44%3A51-05%3A00%20TO%202028-03-06T20%3A44%3A51-05%3A00%5D)%20AND%20event-date-count%3A1))");
           
 

                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Create, isoStore))
                {
                    using (StreamWriter writer = new StreamWriter(isoStream))
                    {
                        writer.Write(json);
                        writer.Flush();
                        writer.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                if(isoStore.FileExists(fileName))
                {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(fileName, FileMode.Open, isoStore))
                    {
                        using (StreamReader reader = new StreamReader(isoStream))
                        {
                            json = reader.ReadToEnd();
                            reader.Close();
                        }
                    }          
                }

                Console.WriteLine(ex.Message);
            }

            return Models.Welcome.FromJson(json);
        }
    }
}
