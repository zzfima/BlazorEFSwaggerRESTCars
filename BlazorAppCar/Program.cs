using BlazorAppCar.Components;
using BlazorAppCar.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<BlazorAppCarContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BlazorAppCarContext") ?? throw new InvalidOperationException("Connection string 'BlazorAppCarContext' not found.")));

builder.Services.AddControllers(); // Register the controllers
builder.Services.AddSwaggerGen();  // Optional: Swagger for API documentation


builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car and Engine API v1");
    });
}

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();  // This maps your API endpoints

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
