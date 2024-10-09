using Dapper;
using ProjetoAula03.Entities;
using ProjetoAula03.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula03.Repositories
{
    /// <summary>
    /// Repositório para executar operações com a tabela de estoque no banco de dados
    /// </summary>
    public class EstoqueRepository
    {
        /// <summary>
        /// Método para inserir um estoque na tabela
        /// </summary>
        /// <param name="estoque">Dados do estoque que será cadastrado</param>
        public void Add(Estoque estoque)
        {
            //escrevendo o comando SQL
            var query = @"
                INSERT INTO ESTOQUE(ID, NOME)
                VALUES(@ID, @NOME)
            ";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                //executando a query no banco de dados
                connection.Execute(query, new {
                    @ID = estoque.Id,
                    @NOME = estoque.Nome
                });
            }
        }

        /// <summary>
        /// Método para atualizar um estoque na tabela 
        /// </summary>
        /// <param name="estoque">Dados do estoque que será atualizado</param>
        public void Update(Estoque estoque)
        {
            //escrevendo o comando SQL
            var query = @"
                UPDATE ESTOQUE 
                SET
                    NOME = @NOME
                WHERE
                    ID = @ID                    
            ";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                //executando a query no banco de dados
                connection.Execute(query, new {
                    @ID = estoque.Id,
                    @NOME = estoque.Nome
                });
            }
        }

        /// <summary>
        /// Método para excluir um estoque na tabela 
        /// </summary>
        /// <param name="id">Identificador do estoque que será excluído</param>
        public void Delete(Guid id)
        {
            //escrevendo o comando SQL
            var query = @"
                DELETE FROM ESTOQUE
                WHERE ID = @ID
            ";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute(query, new { 
                  @ID = id  
                });
            }
        }

        /// <summary>
        /// Método para consultar todos os estoques cadastrados
        /// </summary>
        /// <returns>Lista com os registros de estoques</returns>
        public List<Estoque> GetAll()
        {
            //escrevendo o comando SQL
            var query = @"
                SELECT ID, NOME FROM ESTOQUE
                ORDER BY NOME  
            ";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                //executando a consulta e retornar os resultados
                return connection.Query<Estoque>(query).ToList();
            }
        }

        /// <summary>
        /// Método para consultar 1 estoque no banco de dados através do ID
        /// </summary>
        /// <param name="id">Identificador do estoque que será consultado</param>
        /// <returns>Objeto da classe Estoque ou null se nenhum for encontrado</returns>
        public Estoque GetById(Guid id)
        {
            //escrevendo o comando SQL
            var query = @"
                SELECT ID, NOME FROM ESTOQUE
                WHERE ID = @ID
            ";

            //abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query<Estoque>(query, new {
                    @ID = id
                }).FirstOrDefault();
            }
        }
    }
}
