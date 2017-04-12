using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RPAMicroServices
{
    [DataContract]
    public partial class Ticket
    {
        [DataMember]
        public String TicketId { get; set; }

        [DataMember]
        public String TicketNumber { get; set; }

        [DataMember]
        public String TicketTitle { get; set; }

        [DataMember]
        public String TicketDescription { get; set; }

        //[DataMember]
        //  public SortedList TicketCategories { get; set; }

        [DataMember]
        public String userID { get; set; }
    }
}
