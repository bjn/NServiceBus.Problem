using NServiceBus;

namespace Server.Properties
{
	[EndpointName("sample.server")]	
	public class WorkerConfiguration : IConfigureThisEndpoint, AsA_Publisher
	{
		 
	}
}