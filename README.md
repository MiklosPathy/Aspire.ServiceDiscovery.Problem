**EDIT: This is an aswer now.** I fixed the project to work. Just to have a working example on the web about custom container service discovery, for the example in the Aspire documentation is a bit misleading.

Original text:

Example project demonstrating my Aspire ServiceDiscovery misuse/problem

Run the AppHost, and then click one of the endpoints of the apiservice. It will call the LabseTest method int the LabseClient class, with the "configured" httpClient instance. Except, it is misconfigured, so it tries to call port 80, etc
