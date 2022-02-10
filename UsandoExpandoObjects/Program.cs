using System;
using System.Collections.Generic;
using System.Dynamic;

namespace UsandoExpandoObjects
{
    class Program
    {
        static dynamic expando = new ExpandoObject();
        static void Main(string[] args)
        {

            int op = 0;

            while(op!=3)
            {
                Console.Clear();
                Console.WriteLine("+++ Usando ExpandoObjects +++");
                Console.WriteLine("=== 1- Adicionar Propriedade ao Objeto ===");
                Console.WriteLine("=== 2- Lista Objeto ===");
                Console.WriteLine("=== 3- Sair ===");
                Console.Write(">>> Digite sua opção: ");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Informe uma propriedade: ");
                        string prop = Console.ReadLine();
                        Console.Write("Informe o valor: ");
                        string valor = Console.ReadLine();
                        AdicionarPropriedade(expando, prop, valor);
                        break;
                    case 2:
                        Console.Clear();
                        ListarObjeto(expando);
                        Console.ReadKey();
                        break;
                    case 3:
                         Console.WriteLine("Encerrando. Aperte qualquer tecla para encerrar.");
                         Console.ReadKey();
                         op = 3;
                         break;
                    default: Console.WriteLine("Opção não contemplada no menu.");
                        break;                      
                }
            }
        }

        public static void ListarObjeto(ExpandoObject expo)
        {
            Console.Clear();
            Console.WriteLine("+++ Listando as propriedades do objeto +++");
            var expandoDict = expo as IDictionary<string, object>;
            foreach (var item in expandoDict)
            {
                Console.Write(item.Key);
                Console.Write(" = ");
                Console.WriteLine(item.Value);
            }
        }
        public static void AdicionarPropriedade(ExpandoObject expand, string nomePropriedade, object valorPropriedade)
        {
            // ExpandoObject da suporte a IDictionary então podemos estendê-lo assim:
            var expandoDict = expand as IDictionary<string, object>;
            if (expandoDict.ContainsKey(nomePropriedade))
                expandoDict[nomePropriedade] = valorPropriedade;
            else
                expandoDict.Add(nomePropriedade, valorPropriedade);
        }
    }
}
