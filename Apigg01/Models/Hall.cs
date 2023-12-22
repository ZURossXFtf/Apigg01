using System;
using System.Collections.Generic;

namespace Apigg01.Models;

public partial class Hall
{
    public int IdHall { get; set; }

    public string? Status { get; set; }

    public int? Availableseats { get; set; }

    public int? Occupiedplaces { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
