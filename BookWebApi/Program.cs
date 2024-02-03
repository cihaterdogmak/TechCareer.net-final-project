using System.Reflection;
using BookWebApi.Repository;

var builder = WebApplication.CreateBuilder(args);
// Kitap Yazar ve Kategorilerle alakalı CRUD operasyonları


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
