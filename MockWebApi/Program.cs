using Logger;
using System.Diagnostics;
using ILogger = Logger.ILogger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILogger>(provider =>
{
    EventLogEntryType logLevel = EventLogEntryType.Information;
    return new EventViewerLogger("MockWebApi", logLevel);
});

var app = builder.Build();

//if (app.Environment.IsDevelopment())

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
