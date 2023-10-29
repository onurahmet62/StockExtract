using System;
using System.Collections.Generic;

namespace StockExtract.DataAccess.Models;

public partial class Stk
{
    public int Id { get; set; }

    public string MalKodu { get; set; } = null!;

    public string MalAdi { get; set; } = null!;
}
