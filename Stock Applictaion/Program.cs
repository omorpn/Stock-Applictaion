using ServiceContract;
using Services;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{WebRootPath = "public"});
builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("AppConfig/myconfig.json", optional: true, reloadOnChange: true);
builder.Services.Configure<ApiKeys>(builder.Configuration.GetSection("ApiKeys"));
builder.Services.AddHttpClient();
builder.Services.AddScoped<IWeatherService, WeatherService>();  
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
