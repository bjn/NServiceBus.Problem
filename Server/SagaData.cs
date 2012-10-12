using System;
using NServiceBus.Saga;

namespace Server
{
	public class SagaData : IContainSagaData
	{
		[Unique]
		public Guid CorrelationId { get; set; }

		public DateTime StepA { get; set; }
		public DateTime StepB { get; set; }
		public DateTime StepC { get; set; }

		public Guid Id { get; set; }
		public string Originator { get; set; }
		public string OriginalMessageId { get; set; }
	}
}