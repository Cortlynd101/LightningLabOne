using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);

// 401 un-authorized

// Suposed to work
// Told google, that me web app is trusted
// TODO: My api is ALSO trusted
// Call google in this API
// Token as JWT

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataStore, PostgresDataStore>();
builder.Services.AddDbContext<PostgresContext>(options => options.UseNpgsql(builder.Configuration["db"]));

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Push
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
