using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NSFASBudgetTracker.Core.Entities;
using NSFASBudgetTracker.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepo;

    public AuthController(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(UserDto request)
    {
        if (await _userRepo.GetUserByUsernameAsync(request.Username) != null)
            return BadRequest("Username already exists");

        CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

        var user = new AppUser
        {
            Username = request.Username,
            PasswordHash = hash,
            PasswordSalt = salt
        };

        await _userRepo.AddUserAsync(user);
        return Ok("User created");
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserDto request)
    {
        var user = await _userRepo.GetUserByUsernameAsync(request.Username);
        if (user == null || !VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            return Unauthorized("Invalid credentials");

        string token = CreateToken(user);
        return Ok(token);
    }

    private string CreateToken(AppUser user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecureKey12345"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512();
        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        using var hmac = new System.Security.Cryptography.HMACSHA512(salt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(hash);
    }
}

public class UserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
