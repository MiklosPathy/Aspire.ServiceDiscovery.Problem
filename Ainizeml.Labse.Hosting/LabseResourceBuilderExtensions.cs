using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace Ainizeml.Labse.Hosting
{
    public static class LabseResourceBuilderExtensions
    {
        public static IResourceBuilder<LabseResource> AddLabse(
            this IDistributedApplicationBuilder builder,
            string name,
            int? httpPort = null,
            int? grpcPort = null)
        {
            // The AddResource method is a core API within .NET Aspire and is
            // used by resource developers to wrap a custom resource in an
            // IResourceBuilder<T> instance. Extension methods to customize
            // the resource (if any exist) target the builder interface.
            var resource = new LabseResource(name);

            return builder.AddResource(resource)
                          .WithImage(LabseContainerImageTags.Image)
                          .WithImageRegistry(LabseContainerImageTags.Registry)
                          .WithImageTag(LabseContainerImageTags.Tag)
                          .WithHttpEndpoint(
                              targetPort: LabseResource.LabseRestAPIPort,
                              port: httpPort,
                              name: LabseResource.HttpEndpointName)
                          .WithEndpoint(
                              targetPort: LabseResource.LabseGrpcPort,
                              port: grpcPort,
                              name: LabseResource.GrpcEndpointName);
        }
    }

    internal static class LabseContainerImageTags
    {
        internal const string Registry = "docker.io";
        internal const string Image = "ainizeml/labse";
        internal const string Tag = "latest";
    }
}
