using System;
using System.Collections.Generic;

namespace Backend.Model;

public partial class Imagem
{
    public int Id { get; set; }

    public byte[] Foto { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
