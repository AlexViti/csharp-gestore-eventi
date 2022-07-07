using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Event
    {
        private string title;
        private DateOnly date;
        private int capacity;
        
        public Event(string title, DateOnly date, int capacity)
        {
            try
            {
                this.Title = title;
                this.Date = date;
                this.Capacity = capacity;
                this.Reserved = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Event contructor", ex);
            }             
        }

        public Event(string title, string date, int capacity)
        {
            try
            {
                this.Title = title;
                if (DateOnly.TryParse(date, out _))
                    this.Date = DateOnly.Parse(date);
                else
                    throw new Exception("Date is not formatted properly");
                this.Capacity = capacity;
                this.Reserved = 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Event contructor", ex);
            }
        }
        public string Title
        {
            get => this.title;
            
            set
            {
                if (value == "")
                    throw new ArgumentException("Title cannot be null or empty");                
                this.title = value;
            }
        }
        public DateOnly Date
        {
            get => this.date;
            
            set
            {
                if (value < DateOnly.FromDateTime(DateTime.Now))
                    throw new ArgumentException("Date cannot be in the past");                
                this.date = value;
            }
        }
        public int Capacity
        {
            get => this.capacity;
            
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Capacity cannot be negative");                
                this.capacity = value;
            }
        }
        public int Reserved { get; private set;  }

        public int Available => this.Capacity - this.Reserved;

        public void Book(int n = 1)
        {
            if (Reserved + n > Capacity)
                throw new Exception("Event is full");
            else if (n < 0)
                throw new Exception("Number of seats cannot be negative");
            this.Reserved += n;
        }

        public void Cancel(int n = 1)
        {
            if (Reserved - n < 0)
                throw new Exception("Event is empty");
            else if (n < 0)
                throw new Exception("Number of seats cannot be negative");
            this.Reserved -= n;
        }

        public override string ToString()
        {
            return $"{Date:dd/MM/yyyy} - {Title}";
        }

        public static bool TryCreat(out Event? e)
        {
            Console.Write("Inserisci titolo: ");
            string title = Input.StringNotEmpyty("Title");
            Console.Write("Inserisci data (dd/MM/yyyy): ");
            DateOnly date = Input.FutureDate();
            Console.Write("Inserisci numero posti: ");
            int capacity = Input.PositiveInt();
            try
            {
                e = new(title, date, capacity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                e = null;
                return false;
            }
        }
        
        public static Event Create()
        {
            bool success = false;
            Event ev;
            do
            {
                success = TryCreat(out ev);
            } while (!success);
            return ev!;
        }

    }
}
