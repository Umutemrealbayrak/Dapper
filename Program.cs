using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstateDapper.Models.DapperContext;
using RealEstateDapper.Repositories.CategoryRepository;
using RealEstateDapper.Repositories.ProductRepository;
using RealEstateDapper.Repositories.ServiceRepository;
using RealEstateDapper.Repositories.WhoWeAreDetailRepository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository,ServiceRepository>();
// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
