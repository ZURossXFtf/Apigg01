using System;
using System.Collections.Generic;

namespace Apigg01.Models;

public partial class Repertoire
{
    public int IdRepertoire { get; set; }

    public DateOnly Currenttime { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
