using DevTest.Domain.Models;
using DevTest.Domain.Services;
using DevTest.EntityFramework;
using DevTest.EntityFramework.Services;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Produto_Grupo> productGroupService = new GenericDataService<Produto_Grupo>(new DevTestDbContextFactory());
            /*productGroupService.Create(new Produto_Grupo { nome = "Grupo 1" }).Wait();*/

            IDataService<Produto> productService = new GenericDataService<Produto>(new DevTestDbContextFactory());
            /*productService.Create(new Produto { descricao = "teste", codGrupo=1 , dataHoraCadastro = DateTime.Now }).Wait();*/
            /*Console.WriteLine(productService.GetByID(1).ToString());
            Console.WriteLine(productService.GetAll().Result.Count());*/
            /*Console.WriteLine(productService.Delete(3).Result.ToString());*/

            Console.ReadLine();
        }
    }
}
