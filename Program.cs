using GestoreEventi;

Console.WriteLine("Crea programma eventi");
Console.WriteLine("Inserisci titolo programma: ");
string title = Input.StringNotEmpyty("Title");
Console.WriteLine("Quanti eventi vuoi creare?");
int numberEvents = Input.PositiveInt();

EventProgram program = new(title);

for (int i = 1; i <= numberEvents; i++)
{
    Console.WriteLine("\n\nCrea evento n°{0}: ", i);
    Event ev = Event.Create();
    program.AddEvent(ev);

    bool book;
    do
        book = ev.BookOrCancel(true);
    while (book);

    bool cancel;
    do
        cancel = ev.BookOrCancel(false);
    while (cancel);   
}

Console.WriteLine($"Numero di eventi presenti " + program.Events.Count);
EventProgram.PrintEvents(program.Events);
Console.WriteLine("\n Inserisci una data, ne verranno stampati gli eventi in programma");
EventProgram.PrintEvents(program.GetEventsByDate(Input.FutureDate()));
program.RemoveAll();

