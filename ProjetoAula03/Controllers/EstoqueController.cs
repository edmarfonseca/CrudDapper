using ProjetoAula03.Entities;
using ProjetoAula03.Repositories;

namespace ProjetoAula03.Controllers
{
    /// <summary>
    /// Classe para executar os fluxos relacionados a estoque.
    /// </summary>
    public class EstoqueController
    {
        /// <summary>
        /// Método para realizar o passo a passo de cadastro de estoque.
        /// </summary>
        public void CadastrarEstoque()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE ESTOQUE:\n");

                var estoque = new Estoque
                {
                    Id = Guid.NewGuid()
                };

                Console.Write("INFORME O NOME DO ESTOQUE....: ");
                estoque.Nome = Console.ReadLine();

                var estoqueRepository = new EstoqueRepository();
                estoqueRepository.Add(estoque);

                Console.WriteLine("\nESTOQUE CADASTRADO COM SUCESSO!");
            }
            catch(Exception e)
            {
                Console.WriteLine($"\nFALHA AO CADASTRAR ESTOQUE: {e.Message}");
            }
        }

        /// <summary>
        /// Método para realizar o passo a passo de atualização de estoque.
        /// </summary>
        public void AtualizarEstoque()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÂO DE ESTOQUE:\n");

                Console.Write("INFORME O ID DO ESTOQUE...: ");
                var id = Guid.Parse(Console.ReadLine());

                var estoqueRepository = new EstoqueRepository();
                var estoque = estoqueRepository.GetById(id);

                if(estoque != null)
                {
                    Console.Write("ALTERE O NOME DO ESTOQUE..: ");
                    estoque.Nome = Console.ReadLine();

                    estoqueRepository.Update(estoque);

                    Console.WriteLine("\nESTOQUE ATUALIZADO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nESTOQUE NÃO ENCONTRADO.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"\nFALHA AO ATUALIZAR ESTOQUE: {e.Message}");
            }
        }

        /// <summary>
        /// Método para realizar o passo a passo de exclusão de estoque.
        /// </summary>
        public void ExcluirEstoque()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE ESTOQUE:\n");

                Console.Write("INFORME O ID DO ESTOQUE...: ");
                var id = Guid.Parse(Console.ReadLine());

                var estoqueRepository = new EstoqueRepository();
                var estoque = estoqueRepository.GetById(id);

                if (estoque != null)
                {                   
                    estoqueRepository.Delete(estoque.Id);

                    Console.WriteLine("\nESTOQUE EXCLUÍDO COM SUCESSO.");
                }
                else
                {
                    Console.WriteLine("\nESTOQUE NÃO ENCONTRADO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nFALHA AO EXCLUIR ESTOQUE: {e.Message}");
            }
        }

        /// <summary>
        /// Método para exibir todos os estoques cadastrados
        /// </summary>
        public void ConsultarEstoques()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE ESTOQUES:\n");

                var estoqueRepository = new EstoqueRepository();
                var lista = estoqueRepository.GetAll();

                foreach (var item in lista)
                {
                    Console.WriteLine($"ID: {item.Id} \tNOME: {item.Nome}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFALHA AO CONSULTAR ESTOQUES.");
            }
        }
    }
}
