using Voting.API.Data; // Your namespace for ProductContext

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProductContext>();

var app = builder.Build();

//Listen to port 80 for K8s
app.Urls.Add("http://0.0.0.0:80");
 
// Let Kestrel use environment variable instead of hardcoded port
// Don't manually bind a port unless absolutely necessary

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();