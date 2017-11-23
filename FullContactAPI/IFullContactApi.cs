using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FullContactAPI
{
    interface IFullContactApi
    {
        Task<FullContactPerson> lookupPersonByEmailAsync(String email);
    }

    public class FullContactPerson
    {
        public string likeIHood = "";
        public string contactInfo;
    }

    public static class contactPerson : IFullContactApi
    {
        public async Task<FullContactPerson> lookupPersonByEmailAsync(string email)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-FullContact-APIKey", "256d64494c066cee");
            String response = await client.GetStringAsync("https://api.fullcontact.com/v2/person.json?email=" + email);
            String[] data = response.Split(":");
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("likelihood"))
                {
                    Console.WriteLine("likelihood" + data[i + 1]);
                }
            }
            throw new NotImplementedException();
        }
    }

}
