using System;
using NServiceBus;

namespace Events
{
	[Serializable]
	public class EventB : IEvent
	{
		public Guid CorrelationId { get; set; }
	}
}