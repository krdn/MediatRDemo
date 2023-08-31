using DemoLibrary;
using DemoLibrary.Handlers;
using DemoLibrary.Interface;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Query, Command 핸들러를 등록한다.
// IRequestHandler 인터페이스를 구현한 핸들러를 등록한다.
// IRequest 인터페이스를 구현한 핸들러를 등록한다.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DemoLibraryMediatREntrypoint).Assembly));
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MediatRLoggingBehavior<,>));

//builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();
builder.Services.Scan(scan => scan
        .FromAssemblyOf<DemoLibraryMediatREntrypoint>() // This is scanning the DemoLibrary assembly
        //.FromAssemblies(typeof(DemoLibraryMediatREntrypoint).Assembly) // This is scanning the DemoApi assembly
        //.FromAssemblyOf<ITransientService>()
        .AddClasses(classes => classes.AssignableTo<ITransientService>())
        .AsImplementedInterfaces()
        .WithTransientLifetime() // Transient
        //.FromAssemblyOf<IScopedService>()
        .AddClasses(classes => classes.AssignableTo<IScopedService>())
        .AsImplementedInterfaces()
        .WithScopedLifetime() // Scoped
        //.FromAssemblyOf<ISingletonService>()
        .AddClasses(classes => classes.AssignableTo<ISingletonService>())
        .AsImplementedInterfaces()
        .WithSingletonLifetime() // Singleton
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();