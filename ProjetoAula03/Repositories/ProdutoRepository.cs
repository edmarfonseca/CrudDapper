using Dapper;
using ProjetoAula03.Entities;
using ProjetoAula03.Models;
using ProjetoAula03.Settings;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ProjetoAula03.Repositories
{
    /// <summary>
    /// Repositório para executar operações com a tabela de produto no banco de dados
    /// </summary>
    public class ProdutoRepository
    {
        /// <summary>
        /// Método para inserir um produto na tabela
        /// </summary>
        /// <param name="produto">Dados do estoque que será cadastrado</param>
        public void Add(Produto produto)
        {    
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_INSERIR_PRODUTO", new
                {
                    @ID = produto.Id,
                    @NOME = produto.Nome,
                    @PRECO = produto.Preco,
                    @QUANTIDADE = produto.Quantidade,
                    @ESTOQUE_ID = produto.EstoqueId
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Produto produto)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_UPDATE_PRODUTO", new
                {
                    @ID = produto.Id,
                    @NOME = produto.Nome,
                    @PRECO = produto.Preco,
                    @QUANTIDADE = produto.Quantidade,
                    @ESTOQUE_ID = produto.EstoqueId
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                connection.Execute("SP_DELETE_PRODUTO", new
                {
                    @ID = id
                },
                commandType: CommandType.StoredProcedure);
            }
        }

        public List<Produto> GetAll()
        {
            var query = @"
                SELECT * FROM PRODUTO p
                INNER JOIN ESTOQUE e
                ON e.ID = p.ESTOQUE_ID
                ORDER BY p.NOME  
            ";

            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query(query, (Produto p, Estoque e) => {
                    p.Estoque = e;
                    return p;
                },
                splitOn: "ESTOQUE_ID").ToList();
            }
        }

        public Produto GetById(int id)
        {
            var query = @"
                SELECT * FROM PRODUTO p
                INNER JOIN ESTOQUE e
                ON e.ID = p.ESTOQUE_ID
                WHERE p.ID = @ID
            ";

            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query(query, (Produto p, Estoque e) => {
                    p.Estoque = e;
                    return p;
                },
                new { @ID = id },
                splitOn: "ESTOQUE_ID").FirstOrDefault();
            }
        }

        public List<TotalQuantidadeEstoqueModel> GroupByEstoque()
        {
            var query = @"
                SELECT 
                    e.ID AS IdEstoque,
                    e.NOME AS NomeEstoque,
                    SUM(p.QUANTIDADE) AS TotalQuantidade
                FROM 
                    ESTOQUE e
                LEFT JOIN
                    PRODUTO p ON e.ID = p.ESTOQUE_ID
                GROUP BY
                    e.ID,
                    e.NOME
                ORDER BY
                    e.NOME
            ";

            using (var connection = new SqlConnection(AppSettings.ConnectionString))
            {
                return connection.Query<TotalQuantidadeEstoqueModel>(query).ToList();
            }
        }
    }
}