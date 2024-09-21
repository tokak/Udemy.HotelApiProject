using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace WepApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate()
        {
            // Token için kullanılacak gizli anahtarı byte dizisine dönüştürüyoruz.
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapis");

            // Simetrik bir güvenlik anahtarı oluşturuyoruz.
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            // Token'ın imzasını HmacSha256 algoritması ile oluşturuyoruz.
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // JWT token'ını oluşturuyoruz, issuer (token'ı çıkaran), audience (token'ı alan),
            // token'ın geçerlilik başlangıç zamanı ve bitiş süresi gibi değerleri belirtiyoruz.
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost", // Token'ı çıkaran (issuer)
                audience: "http://localhost", // Token'ı kullanacak olan (audience)
                notBefore: DateTime.Now, // Token'ın geçerli olmaya başlayacağı zaman
                expires: DateTime.Now.AddMinutes(3), // Token'ın geçerlilik süresi (3 dakika)
                signingCredentials: credentials // İmza için kullandığımız bilgiler
            );

            // JWT token'ı yazdırmak için bir JwtSecurityTokenHandler kullanıyoruz.
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // Token'ı yazdırıyoruz. Bu, token'ın bir string formatında döndürülmesini sağlar.
            return handler.WriteToken(token);
        }

        public string TokenCreateAdmin()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapis");
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Visitor")
            };

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: "http://localhost", audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddSeconds(30), signingCredentials: credentials, claims: claims);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }
    }
}
