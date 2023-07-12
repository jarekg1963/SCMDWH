using System;
using System.Collections.Generic;

namespace SCMDWH.Shared.Models;

public partial class Recipient
{
    public long RecipientId { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

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

    public string Contact { get; set; } = null!;

    public string Www { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public string CreateUserId { get; set; } = null!;

    public DateTime? CreateDate { get; set; }

    public string ModifyUserId { get; set; } = null!;

    public string Stamp { get; set; } = null!;

    public bool Recipient1 { get; set; }

    public bool Sender { get; set; }

    public string Sapid { get; set; } = null!;

    public bool Eshipping { get; set; }

    public string Name2 { get; set; } = null!;

    public bool LoadingPlace { get; set; }

    public string Flow { get; set; } = null!;
}
