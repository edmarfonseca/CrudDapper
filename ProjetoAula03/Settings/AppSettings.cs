using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Settings
{
    /// <summary>
    /// Classe para configurar parametros utilizados pelo projeto
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Propriedade para retornar a string de conexão do banco de dados
        /// </summary>
        public static string ConnectionString {
            get {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAula03;Integrated Security=True;";
            }
        }
    }
}
