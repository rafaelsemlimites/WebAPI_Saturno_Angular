using Microsoft.EntityFrameworkCore;
using WebAPI_Saturno.DataContext;
using WebAPI_Saturno.Service.ClienteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API Saturno",
            Version = "v1",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact
            {
                Name = "Rafael Lucaz Chaves",
                Email = "rafaelchaves.ti@gmail.com"
            }
        });

        var xmlFile = "WebAPI_Saturno.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

        c.IncludeXmlComments(xmlPath);

    });

//Relacionamento entre Interface e Metodos
builder.Services.AddScoped<IClienteInterface, ClienteService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

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
