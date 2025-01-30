using Aspire.Hosting.ApplicationModel;

namespace Ainizeml.Labse.Hosting
{
    public sealed class LabseResource(string name) : ContainerResource(name), IResourceWithConnectionString
    {
        // Constants used to refer to well known-endpoint names, this is specific
        // for each resource type. MailDev exposes an SMTP endpoint and a HTTP
        // endpoint.
        internal const string HttpEndpointName = "http";
        internal const int LabseRestAPIPort = 8501;
        internal const string GrpcEndpointName = "grpc";
        internal const int LabseGrpcPort = 8500;

        // An EndpointReference is a core .NET Aspire type used for keeping
        // track of endpoint details in expressions. Simple literal values cannot
        // be used because endpoints are not known until containers are launched.
        private EndpointReference? _httpReference;

        public EndpointReference HttpEndpoint =>
            _httpReference ??= new(this, HttpEndpointName);

        // Required property on IResourceWithConnectionString.
        public ReferenceExpression ConnectionStringExpression =>
            ReferenceExpression.Create(
                $"http://{HttpEndpoint.Property(EndpointProperty.Host)}:{HttpEndpoint.Property(EndpointProperty.Port)}"
            );
    }
}
