using System;
using System.Collections.Generic;

namespace Apigg01.Models;

public partial class Film
{
    public int IdFilm { get; set; }

    public int? IdRepertoire { get; set; }

    public string Name { get; set; } = null!;

    public virtual Repertoire? IdRepertoireNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
