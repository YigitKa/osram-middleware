// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://api-vlrg.osram.info/cars/");
HttpResponseMessage responseMessage = httpClient.GetAsync("lookups?kind_id=1&lang=en&lookuptype=manufacturers").Result;
Console.WriteLine($"Status Code: {responseMessage.StatusCode}");

if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
{
    Console.ForegroundColor = ConsoleColor.Red;
}
Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result);




