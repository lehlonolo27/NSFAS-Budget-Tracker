using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<bool> Register(string username, string password)
    {
        var result = await _http.PostAsJsonAsync("api/auth/register", new { username, password });
        return result.IsSuccessStatusCode;
    }

    public async Task<bool> Login(string username, string password)
    {
        var result = await _http.PostAsJsonAsync("api/auth/login", new { username, password });

        if (!result.IsSuccessStatusCode) return false;

        var token = await result.Content.ReadAsStringAsync();
        await _localStorage.SetItemAsync("authToken", token);

        _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return true;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _http.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> GetUsername()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        if (string.IsNullOrWhiteSpace(token)) return null;

        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);
        var username = jwt.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

        return username;
    }
}
