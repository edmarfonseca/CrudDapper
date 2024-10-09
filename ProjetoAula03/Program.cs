using ProjetoAula03.Controllers;

namespace ProjetoAula03
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nSISTEMA DE CONTROLE DE ESTOQUE E PRODUTOS:\n");

            Console.WriteLine("(1) CADASTRAR ESTOQUE");
            Console.WriteLine("(2) ATUALIZAR ESTOQUE");
            Console.WriteLine("(3) EXCLUIR ESTOQUE");
            Console.WriteLine("(4) CONSULTAR ESTOQUE");

            Console.WriteLine("\n(5) CADASTRAR PRODUTO");
            Console.WriteLine("(6) ATUALIZAR PRODUTO");
            Console.WriteLine("(7) EXCLUIR PRODUTO");
            Console.WriteLine("(8) CONSULTAR PRODUTO");
            Console.WriteLine("\n(9) RELATÓRIO DE PRODUTOS");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcao = int.Parse(Console.ReadLine());

            var estoqueController = new EstoqueController();
            var produtoController = new ProdutoController();

            switch (opcao)
            {
                case 1:
                    estoqueController.CadastrarEstoque();
                    break;
                case 2:
                    estoqueController.AtualizarEstoque();
                    break;
                case 3:
                    estoqueController.ExcluirEstoque();
                    break;
                case 4:
                    estoqueController.ConsultarEstoques();
                    break;

                case 5:
                    produtoController.CadastrarProduto();
                    break;
                case 6:
                    produtoController.AtualizarProduto();
                    break;
                case 7:
                    produtoController.ExcluirProduto();
                    break;
                case 8:
                    produtoController.ConsultarProdutos();
                    break;
                case 9:
                    produtoController.GerarRelatorio();
                    break;
                default:
                    Console.WriteLine("\nOPÇÃO INVÁLIDA!");
                    break;
            }

            Console.Write("\nDESEJA CONTINUAR (S,N): ");
            var continuar = Console.ReadLine();

            if(continuar.ToUpper().Equals("S"))
            {
                Console.Clear(); //limpar o console
                Main(args); //recursividade
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
                Console.ReadKey();
            }
        }
    }
}