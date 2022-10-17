using System.Text.Json;
using dotnet.Model;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// get data
HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://api-vlrg.osram.info/cars/");
HttpResponseMessage responseMessage = httpClient.GetAsync("lookups?kind_id=1&lang=en&lookuptype=manufacturers").Result;
Console.WriteLine($"Status Code: {responseMessage.StatusCode}");

if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
{
    Console.ForegroundColor = ConsoleColor.Red;
}

Manufacturer[]? manufacturers = JsonSerializer.Deserialize<Manufacturer[]>(responseMessage.Content.ReadAsStringAsync().Result);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Araç marka sayisi: {manufacturers?.Count()}");
Console.WriteLine($"********************************************");
Console.WriteLine($"*   id|Name     *");
foreach (Manufacturer manufacturer in manufacturers)
{
    Console.WriteLine($"*   {manufacturer.id}:{manufacturer.name}   *");
}
Console.WriteLine($"********************************************");


