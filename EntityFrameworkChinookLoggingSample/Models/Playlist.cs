﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ChinookLoggingSample.Models;

public partial class Playlist
{
    /// <summary>
    /// Play list primary key
    /// </summary>
    public int PlaylistId { get; set; }

    /// <summary>
    /// Play list name
    /// </summary>
    public string Name { get; set; }

    public virtual ICollection<Track> Track { get; set; } = new List<Track>();
}