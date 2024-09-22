using System.Text.Json;
using static System.Console;
using System;
using System.Net.Http;
using System.Threading.Tasks;

WriteLine("\nDigite o id: ");
var id = ReadLine();

WriteLine("\nRealizando aquisação na API...");
var url = $@"https://api.github.com/user/{id}";
var cliente = new HttpClient();
 cliente.DefaultRequestHeaders.Add("User-Agent", "CSharpApp");
try
{
    HttpResponseMessage? resposta = await cliente.GetAsync(url);
    resposta.EnsureSuccessStatusCode();
    string respostaApiString = await resposta.Content.ReadAsStringAsync();
    WriteLine("Imprimindo todos os dados do json");
    var git = JsonSerializer.Deserialize<GitHubUser>(respostaApiString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    WriteLine("\n Nome: " + git.Name);
    WriteLine("\n Empresa: " + git.Company);
    WriteLine("\n Localização: " + git.Location);
    WriteLine("\n Login " + git.Login);
}
catch (SystemException e)
{
    WriteLine("\n Erro na requisição!" + e.Message);
}
