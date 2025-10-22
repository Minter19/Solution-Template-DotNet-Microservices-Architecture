var builder = WebApplication.CreateBuilder(args);


builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


var app = builder.Build();

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        "/products/openapi/v1.json",
        "Product Service v1"
    );
    options.SwaggerEndpoint(
        "/users/openapi/v1.json",
        "User Service v1"
    );
});

app.MapReverseProxy();

app.MapGet("/", () => "Reverse Proxy is running.");
Console.WriteLine("Reverse Proxy is running.");
app.Run();
