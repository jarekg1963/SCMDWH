using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class Carrier
{
    public long CarrierId { get; set; }

    public string Name { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Adress1 { get; set; } = null!;

    public string Adress2 { get; set; } = null!;

    public string Nip { get; set; } = null!;

    public string Phone1 { get; set; } = null!;

    public string Phone2 { get; set; } = null!;

    public string Phone3 { get; set; } = null!;

    public string Fax1 { get; set; } = null!;

    public string Fax2 { get; set; } = null!;

    public string Fax3 { get; set; } = null!;

    public string Email1 { get; set; } = null!;

    public string Email2 { get; set; } = null!;

    public string Email3 { get; set; } = null!;

    public string Contact1 { get; set; } = null!;

    public string Contact2 { get; set; } = null!;

    public string Contact3 { get; set; } = null!;

    public string Www { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public string Active { get; set; } = null!;

    public string PartyType { get; set; } = null!;

    public string State { get; set; } = null!;

    public string VendorCode { get; set; } = null!;

    public string ZipCode { get; set; } = null!;
}
