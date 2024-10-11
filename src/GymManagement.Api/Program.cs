using GymManagement.Application.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ISubscriptionsService, SubscriptionsService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseRouting();
    app.MapControllers();

    app.Run();
}