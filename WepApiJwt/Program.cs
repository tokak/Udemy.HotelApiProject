using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Authentication �emas�n� JWT olarak ayarl�yoruz.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    // HTTPS zorunlulu�unu kapat�yoruz (geli�tirme ortam� i�in genellikle bu kullan�l�r).
    opt.RequireHttpsMetadata = false;

    // Token do�rulama parametrelerini ayarl�yoruz.
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        // JWT'nin olu�turuldu�u ge�erli 'Issuer' (token'� ��karan).
        ValidIssuer = "http://localhost",

        // JWT'nin ge�erli 'Audience' (token'� alan).
        ValidAudience = "http://localhost",

        // Token'�n imzas�n� do�rulamak i�in kullan�lan gizli anahtar (SymmetricSecurityKey).
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapi")),

        // Token'�n imzas�n�n do�rulan�p do�rulanmayaca��n� belirler.
        ValidateIssuerSigningKey = true,
        
        //Ge�erlilik s�resi
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
