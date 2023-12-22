using System;
using System.Collections.Generic;

namespace Apigg01.Models;

public partial class Ticket
{
    public int? IdFilm { get; set; }

    public int IdTicket { get; set; }

    public int? IdHall { get; set; }

    public int? Price { get; set; }

    public string? Status { get; set; }

    public virtual Film? IdFilmNavigation { get; set; }

    public virtual Hall? IdHallNavigation { get; set; }
}
