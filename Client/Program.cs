using System;
using Events;
using NServiceBus;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			var bus = NServiceBus.Configure.WithWeb()
				.DefineEndpointName("sample.client")
				.Log4Net()
			   .DefaultBuilder()
			   .XmlSerializer()
			   .MsmqTransport()
			   .IsTransactional(false)
			   .PurgeOnStartup(true)
			   .UnicastBus()
			   .ImpersonateSender(false)
			   .CreateBus()
			   .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

			Console.WriteLine("Press Q to quit");

			while (Console.ReadKey().Key != ConsoleKey.Q)
			{
				Guid correlationId = Guid.NewGuid();
				Console.WriteLine("Sending event a with id " + correlationId);

				bus.Send(new EventA() {CorrelationId = correlationId});
			}
		}
	}
}
