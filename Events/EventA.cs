using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Saga;

namespace Events
{
	[Serializable]
    public class EventA : ICommand
    {
		[Unique]
		public Guid CorrelationId { get; set; }
    }
}
