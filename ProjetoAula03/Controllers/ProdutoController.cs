using ProjetoAula03.Entities;
using ProjetoAula03.Repositories;

namespace ProjetoAula03.Controllers
{
    /// <summary>
    /// Classe para executar os fluxos relacionados a Produto.
    /// </summary>
    public class ProdutoController
    {
        /// <summary>
        /// Método para realizar o passo a passo de cadastro de Produto.
        /// </summary>
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE PRODUTO:\n");

                var Produto = new Produto
                {
                    Id = Guid.NewGuid()
                };

                Console.Write("INFORME O NOME DO PRODUTO: ");
                Produto.Nome = Console.ReadLine();

                Console.Write("INFORME O PREÇO .........: ");
                Produto.Preco = Decimal.Parse(Console.ReadLine());

                Console.Write("INFORME A QUANTIDADE ....: ");
                Produto.Quantidade = int.Parse(Console.ReadLine());

                Console.Write("INFORME O ID DO ESTOQUE .: ");
                Produto.EstoqueId = Guid.Parse(Console.ReadLine());

                var ProdutoRepository = new ProdutoRepository();
                ProdutoRepository.Add(Produto);

                Console.WriteLine("\nPRODUTO CADASTRADO COM SUCESSO!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFALHA AO CADASTRAR PRODUTO: {e.Message}");
            }
        }

        /// <summary>
        /// Método para realizar o passo a passo de atualização de Produto.
        /// </summary>
        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE PRODUTO:\n");

                var produto = new Produto();

                Console.Write("INFORME O ID DO PRODUTO .: ");
                produto.Id = Guid.Parse(Console.ReadLine());

                Console.Write("INFORME O NOME DO PRODUTO: ");
                produto.Nome = Console.ReadLine();

                Console.Write("INFORME O PREÇO .........: ");
                produto.Preco = Decimal.Parse(Console.ReadLine());

                Console.Write("INFORME A QUANTIDADE ....: ");
                produto.Quantidade = int.Parse(Console.ReadLine());

                Console.Write("INFORME O ID DO ESTOQUE .: ");
                produto.EstoqueId = Guid.Parse(Console.ReadLine());

                var ProdutoRepository = new ProdutoRepository();
                ProdutoRepository.Update(produto);

                Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSO!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFALHA AO ATUALIZAR PRODUTO: {e.Message}");
            }
        }

        /// <summary>
        /// Método para realizar o passo a passo de exclusão de Produto.
        /// </summary>
        public void ExcluirProduto()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE PRODUTO:\n");

                Console.Write("INFORME O ID DO PRODUTO: ");
                var id = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Delete(id);

                Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSO.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFALHA AO EXCLUIR Produto: {e.Message}");
            }
        }

        /// <summary>
        /// Método para exibir todos os Produtos cadastrados
        /// </summary>
        public void ConsultarProdutos()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE PRODUTOS:\n");

                var produtoRepository = new ProdutoRepository();
                var lista = produtoRepository.GetAll();

                foreach (var item in lista)
                {
                    Console.WriteLine($"ID...............: {item.Id}");
                    Console.WriteLine($"NOME DO PRODUTO..: {item.Nome}");
                    Console.WriteLine($"PREÇO............: {item.Preco.ToString("c")}");
                    Console.WriteLine($"QUANTIDADE.......: {item.Quantidade}");
                    Console.WriteLine($"NOME DO ESTOQUE..: {item.Estoque.Nome}");
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO CONSULTAR PRODUTOS.");
            }
        }

        public void GerarRelatorio()
        {
            try
            {
                Console.WriteLine("\nRELATÓRIO DE PRODUTOS:\n");

                var produtoRepository = new ProdutoRepository();
                var lista = produtoRepository.GroupByEstoque();

                foreach (var item in lista)
                {
                    Console.WriteLine($"ID DO ESTOQUE..........: {item.IdEstoque}");
                    Console.WriteLine($"NOME DO ESTOQUE........: {item.NomeEstoque}");
                    Console.WriteLine($"QTD TOTAL DE PRODUTOS..: {item.TotalQuantidade}");
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFALHA AO CONSULTAR PRODUTOS: {e.Message}");
            }
        }
    }
}