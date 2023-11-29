using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Cupom
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
