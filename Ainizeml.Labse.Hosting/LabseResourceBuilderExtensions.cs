using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace Ainizeml.Labse.Hosting
{
    public static class LabseResourceBuilderExtensions
    {
        public static IResourceBuilder<LabseResource> AddLabse(
            this IDistributedApplicationBuilder builder,
            string name,
            int? httpPort = null)
        {
            var resource = new LabseResource(name);

            return builder.AddResource(resource)
                          .WithImage(LabseContainerImageTags.Image)
                          .WithImageRegistry(LabseContainerImageTags.Registry)
                          .WithImageTag(LabseContainerImageTags.Tag)
                          .WithHttpEndpoint(
                              targetPort: LabseResource.LabseRestAPIPort,
                              port: httpPort,
                              name: LabseResource.HttpEndpointName);
        }
    }

    internal static class LabseContainerImageTags
    {
        internal const string Registry = "docker.io";
        internal const string Image = "ainizeml/labse";
        internal const string Tag = "latest";
    }
}
