using APIFARM.Data;
using APIFARM.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace APIFARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminControler : ControllerBase
    {
        private readonly ApiFarmContext _context;

        public AdminControler(ApiFarmContext context)
        {
            _context = context;
        }

        [NonAction]
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        [NonAction]
        public string HashPassword(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            admin.Salt = GenerateSalt();
            admin.PasswordHash = HashPassword(admin.PasswordHash, admin.Salt);
            admin.PasswordHash = null; 

            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.Id }, admin);
        }
    }
}
