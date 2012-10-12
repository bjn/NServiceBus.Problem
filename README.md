NServiceBus.Problem
===================

1. Set startup projects in solution to
  Client (console application)
  Server (nservicebus host)

2. Make sure server is set to start nservicebus.host.exe in properties/debug

3. Run solution (don't debug)

4. From the client, just press any key except 'q' to send a message to the server

5. Server should receive EventA, publish EventB, receive EventB, publish EventC, Receive EventC and mark as complete.

After a few times this exception is thrown:

2012-10-12 20:44:08,214 [Worker.14] WARN  NServiceBus.Unicast.Transport.Transact
ional.TransactionalTransport [(null)] <(null)> - Failed raising 'transport messa
ge received' event for message with ID=bad8ccdb-65ca-4d8c-9502-2a73f4dad1a8\179088
NServiceBus.Persistence.Raven.ConcurrencyException: A saga with the same Unique
property already existed in the storage. See the inner exception for further det
ails ---> Raven.Abstractions.Exceptions.ConcurrencyException: PUT attempted on document 'saga/33f2d45e-d708-43ad-a42e-a0e80155b63a' using a non current etag
   at Raven.Client.Connection.ServerClient.DirectBatch(IEnumerable`1 commandDatas, String operationUrl)
   at Raven.Client.Connection.ServerClient.<>c__DisplayClass4f.<Batch>b__4e(String u)
   at Raven.Client.Connection.ServerClient.TryOperation[T](Func`2 operation, String operationUrl, Boolean avoidThrowing, T& result)
   at Raven.Client.Connection.ServerClient.ExecuteWithReplication[T](String method, Func`2 operation)
   at Raven.Client.Connection.ServerClient.Batch(IEnumerable`1 commandDatas)
   at Raven.Client.Document.DocumentSession.SaveChanges()
   at NServiceBus.Persistence.Raven.RavenSessionFactory.SaveChanges()
   --- End of inner exception stack trace ---
   at NServiceBus.Unicast.UnicastBus.HandleTransportMessage(IBuilder childBuilder, TransportMessage msg)
   at NServiceBus.Unicast.UnicastBus.TransportMessageReceived(Object sender, TransportMessageReceivedEventArgs e)
   at System.EventHandler`1.Invoke(Object sender, TEventArgs e)
   at NServiceBus.Unicast.Transport.Transactional.TransactionalTransport.OnTransportMessageReceived(TransportMessage msg)
2012-10-12 20:44:08,249 [Worker.14] ERROR NServiceBus.Unicast.Transport.Transact
ional.TransactionalTransport [(null)] <(null)> - Message has failed the maximum
number of times allowed, ID=bad8ccdb-65ca-4d8c-9502-2a73f4dad1a8\179088.