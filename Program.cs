using GestoreEventi;

Console.WriteLine("Crea evento: ");
Event ev = Event.Create();

bool book;
do
    book = BookOrCancel(true);
while (book);

bool cancel;
do
    cancel = BookOrCancel(false);
while (cancel);

bool BookOrCancel(bool book)
{
    Console.WriteLine($"Vuoi {(book ? "riservare" : "cancellare")} dei posti? (yes or no)");
    if (Input.YesOrNo())
    {
        Console.WriteLine($"Quanti posti vuoi {(book ? "riservare" : "cancellare")}");
        int numeroPosti = Input.PositiveInt();
        bool success = false;
        do
        {
            try
            {
                if(book)
                    ev.Book(numeroPosti);
                else
                    ev.Cancel(numeroPosti);
                success = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (!success);
        Console.WriteLine("Ci sono {0} posti riservati e {1} disponibili", ev.Reserved, ev.Available);
        return true;
    }
    else
        return false;
}