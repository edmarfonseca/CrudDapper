using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Entities
{
    /// <summary>
    /// Modelo de dados para a entidade 'Estoque'
    /// </summary>
    public class Estoque
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Relacionamentos

        public List<Produto> Produtos { get; set; }

        #endregion
    }
}
