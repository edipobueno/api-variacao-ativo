using VariacaoAtivo.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication(builder.Configuration);
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

app.UseCors(cfg =>
{
    cfg.AllowAnyHeader();
    cfg.AllowAnyMethod();
    cfg.AllowAnyOrigin();
});

app.Run();