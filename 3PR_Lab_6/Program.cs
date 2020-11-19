using System;
using System.Collections.Generic;

namespace _3PR_Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
			/* Работа с экземплярами класса. */
			Building firstBuilding = new Building();
			Building secondBuilding = new Building();

			Console.WriteLine("Программа по созданию зданий.\nВсе размерные данные вводятся в метрах.\n");
			Console.WriteLine("Работа с экземплярами класса: ");

			firstBuilding.inputBuilding();
			secondBuilding.initBuilding();

			firstBuilding.addToBuilding(secondBuilding);

			firstBuilding.addFloors();
			firstBuilding.removeFloors();
			/*............................................*/
		}
	}
}
