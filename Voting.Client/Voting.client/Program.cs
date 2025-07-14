var builder = WebApplication.CreateBuilder(args);

// Add VotingAPIUrl-based HttpClient with fallback and validation
builder.Services.AddHttpClient("VotingAPIClient", client =>
{
    var VotingApiUrl = builder.Configuration["VotingAPIUrl"];
    Console.WriteLine($">>> CONFIG VotingAPIUrl = '{VotingApiUrl}'");

    if (string.IsNullOrWhiteSpace(VotingApiUrl))
    {
        Console.WriteLine("WARNING: VotingAPIUrl config is missing or empty, using fallback URL.");
        VotingApiUrl = "http://localhost:7211";
    }

    client.BaseAddress = new Uri(VotingApiUrl);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();