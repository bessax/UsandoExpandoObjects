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

            while(true)
            {
                Console.Clear();
                Console.WriteLine("=== 1- Adicionar Propriedade ao Objeto ===");
                Console.WriteLine("=== 2- Lista Objeto ===");
                Console.WriteLine("=== 3- Sair ===");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Informe uma propriedade: ");
                        string prop = Console.ReadLine();
                        Console.Write("Informe uma propriedade: ");
                        string valor = Console.ReadLine();
                        CriarObjeto(prop, valor);
                        break;
                    case 2:
                        Console.Clear();
                        ListarObjeto(expando);
                        Console.Read();
                        break;
                    case 3:
                         Console.WriteLine("Encerrando");
                         Console.ReadKey();
                         return;
                      
                }
            }
        }

        public static void CriarObjeto(string prop,string valor)
        {
            expando.Nome = "André";
            expando.profissao = "Dev";
            expando.prop = valor;
        }
        public static void ListarObjeto(ExpandoObject expo)
        {
            var expandoDict = expo as IDictionary<string, object>;
            foreach (var item in expandoDict)
            {
                Console.Write(item.Key);
                Console.Write("=");
                Console.WriteLine(item.Value);
            }
        }
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject da suporte a IDictionary então podemos estendê-lo assim:
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
