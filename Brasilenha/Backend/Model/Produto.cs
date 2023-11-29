using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string NomeProduto { get; set; } = null!;

    public int ImagemId { get; set; }

    public string Descrição { get; set; } = null!;

    public decimal Valor { get; set; }

    public virtual Imagem Imagem { get; set; } = null!;

    public virtual ICollection<PedidoProduto> PedidoProdutos { get; set; } = new List<PedidoProduto>();
}
