
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MM264;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MM264.Context;
using MM264.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddCors();

builder.WebHost.UseUrls("http://0.0.0.0:5000");



builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });
var app = builder.Build();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/auth/login", (AuthData data, MyDbContext cnt) =>
{
    User user = cnt.Users.FirstOrDefault(u => u.Login == data.Login && u.Password == data.Password);
    if (user != null)

    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, data.Login) };

        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromHours(24)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));

        return Results.Ok(new { User = user, Token = new JwtSecurityTokenHandler().WriteToken(jwt)});
    }
    else
    {
        return Results.Unauthorized();
    }
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/companyes", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Companies.ToList();
});

app.MapGet("/api/criticalthresholdtemplates", [Authorize] (MyDbContext cnt) =>
{
    return cnt.CriticalThresholdTemplates.ToList();
});

app.MapGet("/api/models", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Models.ToList();
});

app.MapGet("/api/notificationtemplates", [Authorize] (MyDbContext cnt) =>
{
    return cnt.NotificationTemplates.ToList();
});

app.MapGet("/api/operators", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Operators.ToList();
});

app.MapGet("/api/paymentmetods", [Authorize] (MyDbContext cnt) =>
{
    return cnt.PaymentMetods.ToList();
});

app.MapGet("/api/paymenttypes", [Authorize] (MyDbContext cnt) =>
{
    return cnt.PaymentTypes.ToList();
});

app.MapGet("/api/vendingmachinespaymenttypes", [Authorize] (MyDbContext cnt) =>
{
    return cnt.PaymenttypeVendingmachines.ToList();
});

app.MapGet("/api/places", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Places.ToList();
});

app.MapGet("/api/products", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Products.ToList();
});

app.MapGet("/api/roles", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Roles.ToList();
});

app.MapGet("/api/sales", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Sales.ToList();
});

app.MapGet("/api/servisepriorities", [Authorize] (MyDbContext cnt) =>
{
    return cnt.ServicePriorities.ToList();
});

app.MapGet("/api/statuses", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Statuses.ToList();
});

app.MapGet("/api/users", [Authorize] (MyDbContext cnt) =>
{
    return cnt.Users.ToList();
});

app.MapGet("/api/vendingmachines", [Authorize] (MyDbContext cnt) =>
{
    return cnt.VendingMachines.ToList();
});

app.MapGet("/api/workmodes", [Authorize] (MyDbContext cnt) =>
{
    return cnt.WorkModes.ToList();
});

app.MapDelete("/api/delete/vendingmachines", [Authorize] (int id, MyDbContext cnt) =>
{
    VendingMachine vendingMachine = cnt.VendingMachines.FirstOrDefault(v => v.Id == id);
    if (vendingMachine != null)
    {
        cnt.VendingMachines.Remove(vendingMachine);
        cnt.SaveChanges();
        return Results.Ok;
    }
    else
    {
        return Results.BadRequest;
    }
});

app.MapDelete("/api/delete/users", [Authorize](int id, MyDbContext cnt) =>
{
    User user = cnt.Users.FirstOrDefault(u => u.Id == id);
    if (user != null)
    {
        cnt.Users.Remove(user);
        cnt.SaveChanges();
        return Results.Ok;
    }
    else
    {
        return Results.BadRequest;
    }
});

app.MapDelete("/api/delete/sales", [Authorize] (int id, MyDbContext cnt) =>
{
    Sale sale = cnt.Sales.FirstOrDefault(s => s.Id == id);
    if(sale != null)
    {
        cnt.Sales.Remove(sale);
        cnt.SaveChanges();
        return Results.Ok;
    }
    else
    {
        return Results.BadRequest;
    }
});

app.MapDelete("/api/delete/products", [Authorize] (int id, MyDbContext cnt) =>
{
    Product product = cnt.Products.FirstOrDefault(p => p.Id == id);
    if (product != null)
    {
        cnt.Products.Remove(product);
        cnt.SaveChanges();
        return Results.Ok;
    }
    else
    {
        return Results.BadRequest;
    }
});

app.MapPost("/api/post/users", [Authorize](User user, MyDbContext cnt) =>
{
    cnt.Attach(user.Role);
    cnt.Users.Add(user);
    cnt.SaveChanges();
    return Results.Ok(user);
});

app.MapPost("/api/post/sales", [Authorize] (Sale sale, MyDbContext cnt) =>
{
    cnt.Attach(sale.PaymentMethod);
    cnt.Attach(sale.Product);
    cnt.Sales.Add(sale);
    cnt.SaveChanges();
    return Results.Ok(sale);
});

app.MapPost("/api/post/products", [Authorize](Product product, MyDbContext cnt) =>
{
    cnt.Attach(product.VendingMachine);
    cnt.Products.Add(product);
    cnt.SaveChanges();
    return Results.Ok(product);
});

app.MapPost("/api/post/vendingmachines", [Authorize] (VendingMachine vending, MyDbContext cnt) =>
{
    cnt.Attach(vending.Company);
    cnt.Attach(vending.User);
    cnt.Attach(vending.CriticalThresholdTemplate);
    cnt.Attach(vending.Model);
    cnt.Attach(vending.NotificationTemplate);
    cnt.Attach(vending.Operator);
    cnt.Attach(vending.Place);
    cnt.Attach(vending.ServicePriority);
    cnt.Attach(vending.Status);
    cnt.Attach(vending.User);
    cnt.Attach(vending.WorkMode);
    cnt.VendingMachines.Add(vending);
    cnt.SaveChanges();
    return Results.Ok(vending);
});

app.Run();

public class AuthOptions
{
    public const string ISSUER = "Masho";
    public const string AUDIENCE = "Vava";
    private const string KEY = "masho2007_vava2003_vadim228Lox323ISIP";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}

public record AuthData(string Login, double Password);