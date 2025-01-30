using Ainizeml.Labse.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var labseModel = builder.AddLabse("labse");
var apiService = builder.AddProject<Projects.Aspire_ServiceDiscovery_WebAPI>("apiservice")
    .WithReference(labseModel)
    .WaitFor(labseModel);

builder.Build().Run();

