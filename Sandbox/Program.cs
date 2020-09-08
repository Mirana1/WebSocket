namespace Sandbox
{
    using System;
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Test;

    public class Program
    {
        static void Main()
        {
            try
            {
                // read file into a string and deserialize JSON to a type
                LoginDTO login = JsonConvert.DeserializeObject<LoginDTO>(File.ReadAllText(@"C:\Users\Asus\Desktop\NRJ\Test\loginReq.json"));
                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(@"C:\Users\Asus\Desktop\NRJ\Test\loginReq.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    LoginDTO loginDto = (LoginDTO)serializer.Deserialize(file, typeof(LoginDTO));
                }
                Console.WriteLine("Success!");

                //taking the query and extracting the params for login
                var loginParams = login.Qry;
                LoginParamsDTO loginParamsJson = JsonConvert.DeserializeObject<LoginParamsDTO>(loginParams);
                Console.WriteLine(loginParamsJson.Password);
            }

            catch (Exception ms)
            {
                Console.WriteLine(ms.Message);
            }
        }
    }
}
