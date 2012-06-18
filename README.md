EasyLog
=======

Introduction
------------

EasyLog is an easy-to-use, minimalist .NET logging library.

Log Writers
-------

Coming soon... 

Examples
--------

### The simplest setup

This example demonstrates a very simple log setup, with a single backend and a single client.

	// Create a new log
	var log = new Log();
	// Create a ringbuffer backend
	var writer = new RingbufferWriter();
	// Add the backend to the log
	log.Writers.Add(writer);

	// Now, get a LogClient. In this case, we get the unnamed default client.
	var client = log.GetDefaultClient();
	// Now we can write to the log, using the new client
	client.Debug("Debug Messages!");
	// Or write conditional messages
	client.WarnIf("There might be a problem", 5 > 10);

	// If you want to check written lines, ask the backend
	var lines = writer.GetEntries();

### Multiple writers

This example demonstrates a log setup with more than one log writer.

	// Again, create a log
	var log = new Log();
	// Create 2 writers this time, a ringbuffer writer and a FileWriter.
	// And add them to the log. Simple.
	var rbWriter = new RingbufferWriter();
	var fWriter = new FileWriter(@"C:\logfile.txt");
	log.Writers.Add(rbWriter);
	log.Writers.Add(fWriter);

	