using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Entities
{
    /// <summary>
    /// Modelo de dados para a entidade 'Produto'
    /// </summary>
    public class Produto
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public Guid EstoqueId { get; set; }

        #endregion

        #region Relacionamentos

        public Estoque Estoque { get; set; }

        #endregion
    }
}
