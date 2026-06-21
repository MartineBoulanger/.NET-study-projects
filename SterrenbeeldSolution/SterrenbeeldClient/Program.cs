using var client = new HttpClient();

Console.Write("Geef de maand in (1-12): ");
string? maandInput = Console.ReadLine()!;
Console.Write("Geef de dag in (1-31): ");
string? dagInput = Console.ReadLine()!;
Console.WriteLine();

if (!int.TryParse(maandInput, out int maand) || !int.TryParse(dagInput, out int dag))
{
    Console.WriteLine("Ongeldige invoer. Geef geldige getallen op voor maand en dag.");
    return;
}

var uri = $"http://localhost:5000/sterrenbeelden/{maand}/{dag}";

try
{
    HttpResponseMessage response = await client.GetAsync(uri);
    string resultaat = await response.Content.ReadAsStringAsync();
    if (response.IsSuccessStatusCode)
        Console.WriteLine($"Jouw sterrenbeeld is: {resultaat}");
    else
        Console.WriteLine($"Fout van de service: {resultaat}");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"Kon de service niet bereiken: {ex.Message}");
}