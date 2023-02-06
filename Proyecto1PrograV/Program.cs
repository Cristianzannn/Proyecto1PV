using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;
using ProyectoApi.DataAccess.Models;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProyectoProgra5Context>(options =>
{
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//app.MapGet("*/clientes", async (ProyectoProgra5Context context) =>
//{
//    return Results.Ok(await context.Clientes.ToListAsync());
//});
//app.MapGet("clientes/{id}", async (int id, ProyectoProgra5Context context) =>
//{
//    if (await context.Clientes.AnyAsync<Cliente>(x => x.ClienteId == id))
//    {
//        return Results.Ok(await context.Clientes.FirstAsync<Cliente>(x => x.ClienteId == id));
//    }
//    return Results.NotFound();
//});

//app.MapPost("/clientes", async ([FromBody] Cliente cliente, ProyectoProgra5Context context) =>
//{

//    try
//    {
//        if (!MiniValidator.TryValidate(cliente, out var errors))
//        {
//            return Results.BadRequest(new { codigo = -2, mensaje = "Datos Incorrectos", errores = errors });
//        }
//        await context.Clientes.AddAsync(cliente);
//        await context.SaveChangesAsync();
//        context.Entry(cliente).Reference(c => c.EstadoNavigation).Load();
//        return Results.Created($"/clientes/{cliente.ClienteId}",
//        new
//        {
//            codigo = 0,
//            mensaje = "Creacion Exitosa",
//            cliente = cliente,
//            nombreEstado = cliente.EstadoNavigation!.Nombre
//        });


//    }

//    catch (Exception exc)

//    {

//        return Results.Json(new
//        {
//            codigo = -1,
//            mensaje = exc.Message
//        },
//            statusCode: StatusCodes.Status500InternalServerError);

//    }
//});

app.MapPost("/ParametrosSensibilidad", async ([FromBody] ParametrosSensibilidad para, ProyectoProgra5Context context) =>
{

    try
    {
        if (!MiniValidator.TryValidate(para, out var errors))
        {
            return Results.BadRequest(new {  codigo= -2, mensaje = "Datos Incorrectos", errores = errors });
        }
        await context.ParametrosSensibilidads.AddAsync(para);
        await context.SaveChangesAsync();
        //context.Entry(para).Reference(c => c.EstadoNavigation).Load();
        return Results.Created($"/ParametrosSensibilidad/{para.NombreParametro}",
        new
        {
            codigo = 0,
            mensaje = "Creacion Exitosa",
            para = para,
            //nombreEstado = cliente.EstadoNavigation!.Nombre
        });


    }

    catch (Exception exc)

    {

        return Results.Json(new
        {
            codigo = -1,
            mensaje = exc.Message
        },
            statusCode: StatusCodes.Status500InternalServerError);

    }
});
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();


internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}