﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CalendarSqlQuerySample.Models;

public partial class People
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool? Gender { get; set; }

    public DateTime? BirthDay { get; set; }

    public string PhoneNumber { get; set; }
}