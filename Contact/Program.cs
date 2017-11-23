using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Contact
{
    class Program
    {
        static void Main(string[] args)
        {
            String email = "";
            
            Console.WriteLine("Enter e-mail");
            email = Console.ReadLine();
            doTheThing(email);

            Console.ReadKey();
        }
        public static async Task doTheThing(String email)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-FullContact-APIKey", "************");
            String response = await client.GetStringAsync("https://api.fullcontact.com/v2/person.json?email=" + email);
            String[] data = response.Split(":");
        
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Contains("likelihood"))
                {
                    Console.WriteLine("likelihood" + data[i + 1]);
                }
            }

            Console.WriteLine(response);
        }
    }
}

