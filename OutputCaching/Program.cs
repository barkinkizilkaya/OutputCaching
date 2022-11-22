using Microsoft.AspNetCore.OutputCaching;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder =>
    {
        builder.Expire(TimeSpan.FromSeconds(30));
    });
    options.AddPolicy("ByQuery",policy =>
    {
        policy.Expire(TimeSpan.FromSeconds(30));
        policy.SetVaryByQuery("Culture");
    });
});
var app = builder.Build();
app.UseOutputCache();

app.MapGet("/",[OutputCache( Duration =5)] () =>
{
    return Results.Ok(DateTime.Now);
}).CacheOutput();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

