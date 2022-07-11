using IoC.Extenstion.TestTarget;
using IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAssemblyExports(typeof(ClassForReferenceOnly).Assembly);
builder.Services.AddAssemblyFolderExports(AppContext.BaseDirectory);


var app = builder.Build();


app.MapGet("/bool", (IService1 s) => "Hello World! " + s.GetBool());
app.MapGet("/int", (IService2 s) => "Hello World! " + s.GetInt());

app.Run();