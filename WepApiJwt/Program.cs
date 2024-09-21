using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Authentication þemasýný JWT olarak ayarlýyoruz.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    // HTTPS zorunluluðunu kapatýyoruz (geliþtirme ortamý için genellikle bu kullanýlýr).
    opt.RequireHttpsMetadata = false;

    // Token doðrulama parametrelerini ayarlýyoruz.
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        // JWT'nin oluþturulduðu geçerli 'Issuer' (token'ý çýkaran).
        ValidIssuer = "http://localhost",

        // JWT'nin geçerli 'Audience' (token'ý alan).
        ValidAudience = "http://localhost",

        // Token'ýn imzasýný doðrulamak için kullanýlan gizli anahtar (SymmetricSecurityKey).
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapi")),

        // Token'ýn imzasýnýn doðrulanýp doðrulanmayacaðýný belirler.
        ValidateIssuerSigningKey = true,
        
        //Geçerlilik süresi
        ValidateLifetime = true,

        ClockSkew = TimeSpan.Zero

        
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
