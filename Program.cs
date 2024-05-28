using RhizomaAlismatisBackend.Models;
using RhizomaAlismatisBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string myAllowSpecifiedOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//允许跨域请求
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecifiedOrigins,
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.WithOrigins();
        });
});

builder.Services.Configure<MusicBoxDatabase>(builder.Configuration.GetSection("MusicBoxDatabase"));
builder.Services.AddSingleton<MusicBoxService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecifiedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();