using GestoreEventi;

Event ev = new Event("Evento", DateOnly.FromDateTime(DateTime.Now), 1000);
Console.WriteLine(ev.ToString());