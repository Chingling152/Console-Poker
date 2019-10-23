using System;

namespace InteliTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            //criar mesa para os jogadores
            Table table = new Table(4);

            foreach (var item in table.Players)
            {
                //mostrar a mão de todos os jogadores
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"\n==========Winner==========\n{table.Winner()}");
        }

    }
}
