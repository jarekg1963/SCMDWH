﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace SCMDWH.Shared.Models;

public partial class GlobalAppRoles
{
	
	public string RoleName { get; set; }

	public string Remarks { get; set; }


	public virtual ICollection<GlobalAppUserRoles> GlobalAppUserRoles { get; } = new List<GlobalAppUserRoles>();
}