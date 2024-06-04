var command = Console.ReadLine();
HttpClient httpClient = new HttpClient();
try
{
    var argumentsArray = command.Split(" ");
    if(argumentsArray == null || argumentsArray.Length < 2)
    {
        Console.WriteLine("Invalid arguments");
        return;
    }
    if (argumentsArray[0].StartsWith("24h"))
    {
        if (argumentsArray.Length != 2)
        {
            Console.WriteLine("Invalid arguments.");
            return;
        }
        var symbol = argumentsArray[1];
        var response = await httpClient.GetAsync($"https://localhost:7236/api/{symbol}/24hAvgPrice");
        Console.Write(await response.Content.ReadAsStringAsync());
    }
    else if (argumentsArray[0].StartsWith("sma"))
    {
        //sma btcusdt 20 1w 12.12.2020
        if (argumentsArray.Length != 5)
        {
            Console.WriteLine("Invalid arguments.");
            return;
        }
        var symbol = argumentsArray[1];
        var n = argumentsArray[2];
        var p = argumentsArray[3];
        var s = argumentsArray[4];
        var response = await httpClient.GetAsync($"https://localhost:7236/api/{symbol}/SimpleMovingAverage?n={n}&p={p}&s={s}");
        Console.Write(await response.Content.ReadAsStringAsync());
    }
    else
    {
        Console.WriteLine("Invalid command.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Exception occured: {ex.Message}");
}
finally
{
    Console.ReadKey();
}

