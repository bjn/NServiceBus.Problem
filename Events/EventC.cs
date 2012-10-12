using System;
using NServiceBus;

namespace Events
{
		[Serializable]
	public class EventC : IEvent
	{
		public Guid CorrelationId { get; set; }
	}
}