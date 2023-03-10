
using Stripe;
var corsNamedPolicy = "policy";

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = builder.Configuration["AllowedOrigins"];
if (string.IsNullOrWhiteSpace(allowedOrigins))
{
    allowedOrigins = Environment.GetEnvironmentVariable("MARSHA_API_ALLOWED_ORIGINS") ?? string.Empty;
}

var apiKey = builder.Configuration["Stripe:ApiKey"];
if (string.IsNullOrWhiteSpace(apiKey))
{
    StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("MARSHA_SITE_STRIPE_KEY") ?? string.Empty;
}

// Add services to the container.
builder.Services.AddCors(opt =>
{

    if (!string.IsNullOrWhiteSpace(allowedOrigins))
    {
        opt.AddPolicy(corsNamedPolicy,
        policy =>
        {
            var AllowedOrigins = allowedOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            policy.WithOrigins(AllowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
    }
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(corsNamedPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();