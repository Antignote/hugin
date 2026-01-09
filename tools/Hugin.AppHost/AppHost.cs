var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hugin_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");


builder.AddKubernetesEnvironment("k8s")
    .WithProperties(k8s =>
    {
        k8s.HelmChartName = "Hugin";
    });

builder.Build().Run();
