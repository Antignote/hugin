var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hugin_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.Build().Run();
