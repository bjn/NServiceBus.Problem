using System;
using Events;
using NServiceBus;
using NServiceBus.Saga;

namespace Server
{
	public class Handler : 
		Saga<SagaData>,
		IAmStartedByMessages<EventA>,
		IHandleMessages<EventB>,
		IHandleMessages<EventC>
    {

		public override void ConfigureHowToFindSaga()
		{
			ConfigureMapping<EventA>(s => s.CorrelationId, m => m.CorrelationId);
			ConfigureMapping<EventB>(s => s.CorrelationId, m => m.CorrelationId);
			ConfigureMapping<EventC>(s => s.CorrelationId, m => m.CorrelationId);
		}

	    public void Handle(EventA message)
	    {
		    Console.WriteLine("Event A " + message.CorrelationId);
		    Data.CorrelationId = message.CorrelationId;
		    Data.StepA = DateTime.Now;
			Bus.Publish(new EventB() {CorrelationId = message.CorrelationId});
	    }
		
		public void Handle(EventB message)
		{
			Console.WriteLine("Event B " + message.CorrelationId);
			Data.StepB = DateTime.Now;
			Bus.Publish(new EventC() {CorrelationId = message.CorrelationId});
		}

		public void Handle(EventC message)
		{
			Console.WriteLine("Event C " + message.CorrelationId);
			Data.StepC = DateTime.Now;
			MarkAsComplete();
		}

	    public void Timeout(object state)
	    {
	    }

    }
}
