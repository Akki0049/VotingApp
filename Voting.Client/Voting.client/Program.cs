var builder = WebApplication.CreateBuilder(args);
// Add VotingAPIUrl-based HttpClient
builder.Services.AddHttpClient("VotingAPIClient", client =>
{
    var VotingApiUrl = builder.Configuration["VotingAPIUrl"];
    Console.WriteLine($">>> CONFIG VotingAPIUrl = {VotingApiUrl}");

    client.BaseAddress = new Uri(VotingApiUrl ?? "http://fallback.local"); // fallback optional
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