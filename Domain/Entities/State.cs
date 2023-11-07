﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class State
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int IdcountryFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdcountryFkNavigation { get; set; }
}
