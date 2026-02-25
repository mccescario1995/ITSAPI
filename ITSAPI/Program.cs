using ITSAPI.Models;
using ITSAPI.Services;
using ITSAPI.TokenAuthentication;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("sql-cons");

builder.Services.AddDbContext<ItsDbContext>(options =>
    options.UseSqlServer(connectionString)
);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:3000",
                "http://localhost:80",
                "http://localhost",
                "http://192.168.136.64",
                "https://apps.fastlogistics.com.ph/its"
                )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();

        //policy
        //    .AllowAnyOrigin()
        //    .AllowAnyMethod()
        //    .AllowAnyHeader()
        //    .AllowCredentials();
    });
});

// SESSION
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

//Token manager(optional now)
builder.Services.AddScoped<ITokenManager, TokenManager>();

// Email Notification Service
builder.Services.AddScoped<EmailNotificationService>();
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseCors("Policy");

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();


//
//
// Previous version with JWT Authentication
//
//

//using ITSAPI.Models;
//using ITSAPI.TokenAuthentication;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("sql-cons");

//builder.Services.AddDbContext<ItsDbContext>(options => options.UseSqlServer(connectionString));

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddCors(o =>
//    o.AddPolicy(
//        "Policy",
//        builder =>
//        {
//            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
//        }
//    )
//);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
//            ValidAudience = builder.Configuration["JwtSettings:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
//        };
//    });

//builder.Services.AddScoped<ITokenManager, TokenManager>();


//var app = builder.Build();

//app.UseCors("Policy");

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


