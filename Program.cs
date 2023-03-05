
using Stripe;
var corsNamedPolicy = "policy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(corsNamedPolicy,
    policy =>
    {
        var AllowedOrigins = (builder.Configuration["AllowedOrigins"] ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        policy.WithOrigins(AllowedOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod();

    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

StripeConfiguration.ApiKey = builder.Configuration["Stripe:ApiKey"].ToString();
app.UseHttpsRedirection();

app.UseCors(corsNamedPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();