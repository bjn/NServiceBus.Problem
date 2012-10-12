using NServiceBus;
using NServiceBus.Config;

namespace Server
{
	[EndpointName("sample.server")]	
	public class WorkerConfiguration : IConfigureThisEndpoint, AsA_Publisher, INeedInitialization
	{
		public void Init()
		{
			Configure.Instance.DisableSecondLevelRetries();
		}
	}
}