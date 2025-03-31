﻿using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans((_, silo) => silo
    .UseLocalhostClustering()
    .AddMemoryGrainStorageAsDefault()
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Example eShop API by team A of 2", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    _ = app.UseSwagger().UseSwaggerUI(options => options.EnableTryItOutByDefault());

app.RegisterEndpoints(
    typeof(InnoWvateDotNet.eShop.Apis.BasketApi.BasketsEndpoints)
);

app.Run();
