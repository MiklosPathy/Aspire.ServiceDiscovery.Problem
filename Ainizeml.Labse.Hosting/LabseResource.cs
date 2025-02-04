using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace Ainizeml.Labse.Hosting
{
    public sealed class LabseResource(string name) : ContainerResource(name), IResourceWithServiceDiscovery
    {
        internal const string HttpEndpointName = "http";
        internal const int LabseRestAPIPort = 8501;
    }
}
