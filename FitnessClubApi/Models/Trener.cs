using System;
using System.Collections.Generic;

namespace FitnessClubApi.Models;

public partial class Trener
{
    public string Dolshnost { get; set; } = null!;

    public int Identificatortrener { get; set; }

    public string Fio { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public virtual ICollection<Raspisanie> Raspisanies { get; } = new List<Raspisanie>();
}
