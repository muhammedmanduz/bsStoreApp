using Microsoft.EntityFrameworkCore;
using Repositories.EfCore;
using WebApi.Extension;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

//builder.Services.AddControllers()
              //  .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
               // .AddNewtonsoftJson();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IoC ye DbContext tanýmýný veriyorum:bir db contex ihtiyacýmýz oldugunda (injection yaptýgýmýz zaman)
//bunu somut halýne ýzýn verercektýr baglanýrken sorun yasanmayacaktýr
//service extensiona aldýk
//builder.Services.AddDbContext<RepositoryContext>(options=>
//options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));


builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
