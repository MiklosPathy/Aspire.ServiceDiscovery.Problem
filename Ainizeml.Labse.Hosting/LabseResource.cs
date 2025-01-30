using Aspire.Hosting.ApplicationModel;

namespace Ainizeml.Labse.Hosting
{
    public sealed class LabseResource(string name) : ContainerResource(name), IResourceWithConnectionString
    {
        internal const string HttpEndpointName = "http";
        internal const int LabseRestAPIPort = 8501;

        private EndpointReference? _httpReference;

        public EndpointReference HttpEndpoint =>
            _httpReference ??= new(this, HttpEndpointName);

        public ReferenceExpression ConnectionStringExpression =>
            ReferenceExpression.Create(
                $"http://{HttpEndpoint.Property(EndpointProperty.Host)}:{HttpEndpoint.Property(EndpointProperty.Port)}"
            );
    }
}
