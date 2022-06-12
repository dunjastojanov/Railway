using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway.model
{
    public class TicketSeat
    {
        public int Wagon { get; set; }  
        public char Column { get; set; }
        public int Row { get; set; }

        public TicketSeat()
        {
        }

        public TicketSeat(int wagon, char column, int row)
        {
            Wagon = wagon;
            Column = column;
            Row = row;
        }

        public TicketSeat DeepCopy()
        {
            TicketSeat newTicketSeat = new TicketSeat();
            newTicketSeat.Wagon = Wagon;
            newTicketSeat.Column = Column;
            newTicketSeat.Row = Row;
            return newTicketSeat;
        }
    }
}
