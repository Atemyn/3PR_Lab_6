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

			/* Динамический массив экземпляров. */
			List<Building> firstDynamicArray = new List<Building>();
			Building helpBuilding = new Building();

			Console.WriteLine("\nДинамический массив объектов: ");

			firstDynamicArray.Add(new Building());
			firstDynamicArray[0].inputBuilding();
			firstDynamicArray.Add(new Building());
			firstDynamicArray[1].initBuilding();
			firstDynamicArray[0].addToBuilding(firstDynamicArray[1]);
			/*...............................*/

			const int amount = 2;
		}
	}
}
