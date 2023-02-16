using System;
using System.Collections.Generic;

namespace FitnessClubApi.Models;

public partial class Gruppa
{
    public string Названиеgruppi { get; set; } = null!;

    public string? Примечание { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual ICollection<Raspisanie> Raspisanies { get; } = new List<Raspisanie>();
}
