﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class GlobalAppUserRoles
{
    public long Id { get; set; }

    public string UserName { get; set; }

    public string RoleName { get; set; }

    public DateTime AddTime { get; set; }

    public string AddByUser { get; set; }

    public virtual GlobalAppRoles RoleNameNavigation { get; set; }

    public virtual GlobalAppUsers UserNameNavigation { get; set; }
}