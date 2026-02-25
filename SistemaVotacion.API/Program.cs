using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SistemaVotacionAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SistemaVotacionAPIContext") ?? throw new InvalidOperationException("Connection string 'SistemaVotacionAPIContext' not found.")));


builder.Services
    .AddControllers()
    .AddNewtonsoftJson(
        options => options.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.//
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
