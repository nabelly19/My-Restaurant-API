using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Pedido
{
    public int Id { get; set; }

    public string CodigoPedido { get; set; } = null!;

    public int UsuarioId { get; set; }

    public DateTime DataPedido { get; set; }

    public int? CupomId { get; set; }

    public virtual Cupom? Cupom { get; set; }

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();

    public virtual Usuario Usuario { get; set; } = null!;
}
