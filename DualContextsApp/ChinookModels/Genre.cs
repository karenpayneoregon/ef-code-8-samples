﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DualContextsApp.ChinookModels;

public partial class Genre
{
    /// <summary>
    /// Genre primary key
    /// </summary>
    public int GenreId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    public virtual ICollection<Track> Track { get; set; } = new List<Track>();
}