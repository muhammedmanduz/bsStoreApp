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

//IoC ye DbContext tan�m�n� veriyorum:bir db contex ihtiyac�m�z oldugunda (injection yapt�g�m�z zaman)
//bunu somut hal�ne �z�n verercekt�r baglan�rken sorun yasanmayacakt�r
//service extensiona ald�k
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
