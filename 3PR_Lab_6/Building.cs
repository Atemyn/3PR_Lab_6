using System;
using System.Collections.Generic;
using System.Text;

namespace _3PR_Lab_6
{
    class Building
    {
		// Длина стороны основания.
		private double sideLength;
		// Высота фундамента.
		private double basementHeight;
		// Высота этажа.
		private double floorHeight;
		// Количество этажей.
		private int floorAmount;
		// Объект класса фасада здания, содержащий информацию об окнах здания.
		private Facade facade = new Facade();
		// Коэффициент устойчивости.
		private double stabilityFactor;
		/* Функция по установке переданных значений в свойства экземпляра класса Building. */
		private void setBuiling(double sideLength, double basementHeight, double floorHeight, int floorAmount, double stabilityFactor)
		{
			this.sideLength = sideLength;
			this.basementHeight = basementHeight;
			this.floorHeight = floorHeight;
			this.floorAmount = floorAmount;
			this.stabilityFactor = stabilityFactor;
		}
		/* Функция по выводу свойств экземпляра класса Building. */
		public void getBuilding()
		{
			Console.WriteLine("Свойства данного здания:");
			Console.WriteLine("Длина стороны основания: " + sideLength);
			Console.WriteLine("Высота фундамента: " + basementHeight);
			Console.WriteLine("Высота этажа: " + floorHeight);
			Console.WriteLine("Количество этажей: " + floorAmount);
			facade.getFacade();
			Console.WriteLine("Коэффициент устойчивости: " + stabilityFactor + "\n");
		}
		/* Функция по заданию свойств по умолчанию экземпляра класса Building. */
		public void initBuilding()
		{
			setBuiling(1.0, 1.0, 1.0, 1, 1.0);
			facade.setFacade(0, 0);
		}
		/* Функция по вводу с клавиатуры свойств для экземпляра класса Building */
		public void inputBuilding()
		{
			// Защиты от дурака для ввода всех необходимых данных.
			Console.Write("Введите длину стороны вашего здания: ");
			while (!double.TryParse(Console.ReadLine(), out sideLength) || sideLength <= 0)
			{
				Console.Write("Неверный ввод длины стороны - она должна быть положительным числом. Попробуйте еще раз: ");
			}

			Console.Write("Введите высоту фундамента вашего здания: ");
			while (!double.TryParse(Console.ReadLine(), out basementHeight) || basementHeight <= 0)
			{
				Console.Write("Неверный ввод высоты фундамента - она должна быть положительным числом. Попробуйте еще раз: ");
			}

			Console.Write("Введите высоту одного этажа вашего здания: ");
			while (!double.TryParse(Console.ReadLine(), out floorHeight) || floorHeight <= 0)
			{
				Console.Write("Неверный ввод высоты этажа - она должна быть положительным числом. Попробуйте еще раз: ");
			}

			Console.Write("Введите количество этажей вашего здания: ");
			while (!int.TryParse(Console.ReadLine(), out floorAmount) || floorAmount <= 0)
			{
				Console.Write("Неверный ввод количества - оно должно быть положительным целым числом. Попробуйте еще раз: ");
			}
			facade.inputFacade();
			// Расчет коэффицента устойчивости.
			stabilityFactor = (float)(sideLength * sideLength * Math.Sqrt(basementHeight)) / (floorHeight * floorAmount);
			// Если коэффициент устойчивости меньше 1 - здание упадет; необхлдим повторный ввод характеристик
			if (stabilityFactor < 1.0)
			{
				Console.WriteLine("Коэффициент стабильности вашего здания k = " + stabilityFactor + " меньше единицы. Оно может рухнуть с минуты на минуту. Хотите ли перестроить его?");
				Console.WriteLine("Если НЕТ - нажмите Esc, если ДА - любую другую кнопку.\n");
				if (Console.Read() != 27)
				{
					inputBuilding();
				}
				else
				{
					Console.WriteLine("Здание не смогло устоять и рухнуло!\n\n");
					initBuilding();
				}
			}
			else
			{
				Console.WriteLine("Отлично! Здание получилось устойчивым с коэффициентом устойчивости k = " + stabilityFactor + ".\n\n");
			}
		}
		/* Функция по сложению двух экземпляров класса Building, где build - экземпляр, который будет прибавляться. */
		public void addToBuilding(Building build)
		{
			Console.WriteLine("Совмещаем два здания... Их свойства такие:");
			Console.WriteLine("Длины сторон оснований: " + sideLength + " и " + build.sideLength);
			Console.WriteLine("Высоты фундаментов: " + basementHeight + " и " + build.basementHeight);
			Console.WriteLine("Высоты этажей: " + floorHeight + " и " + build.floorHeight);
			Console.WriteLine("Количества этажей: " + floorAmount + " и " + build.floorAmount);
			Console.WriteLine("Коэффициенты устойчивости: " + stabilityFactor + " и " + build.stabilityFactor);
			Console.WriteLine("Общие количества окон: " + facade.WindowsAmount + " и " + build.facade.WindowsAmount);
			Console.WriteLine("Количества открытых окон: " + facade.OpenedWindowsAmount + " и " + build.facade.OpenedWindowsAmount + "\n");

			if (sideLength < build.sideLength)
				sideLength = build.sideLength;

			if (basementHeight < build.basementHeight)
				basementHeight = build.basementHeight;

			if (floorHeight < build.floorHeight)
				floorHeight = build.floorHeight;

			floorAmount = floorAmount + build.floorAmount;

			facade.addToFacade(build.facade);
			// Расчет нового коэффициента устойчивости и проверка его корректности.
			stabilityFactor = (float)(sideLength * sideLength * Math.Sqrt(basementHeight)) / (floorHeight * floorAmount);
			if (stabilityFactor < 1)
			{
				Console.WriteLine("К сожалению, после совмещения двух зданий новое здание сразу же развалилось, так как его коэффициент устойчивости k = " + stabilityFactor + " меньше нуля.\n");
				initBuilding();
			}
			else
			{
				Console.WriteLine("Отлично! Новое здание устояло. Его свойства такие:\n");
				getBuilding();
			}
		}
		/* Функция по добавлению floorsToAdd этажей экземпляру класса Building. */
		public void addFloors()
		{
			int floorsToAdd;
			// Защита от дурака для ввода floorsToAdd.
			Console.Write("Введите количество этажей для добавления к вашему зданию: ");
			while (!int.TryParse(Console.ReadLine(), out floorsToAdd) || floorsToAdd < 0)
			{
				Console.Write("Неверный ввод количества - оно должно быть неотрицательным целым числом. Попробуйте еще раз: ");
			}

			floorAmount = floorAmount + floorsToAdd;
			// Расчет нового коэффициента устойчивости и проверка его корректности.
			stabilityFactor = (float)(sideLength * sideLength * Math.Sqrt(basementHeight)) / (floorHeight * floorAmount);
			if (stabilityFactor < 1.0)
			{
				Console.WriteLine("Коэффициент стабильности вашего здания k = " + stabilityFactor +
					" стал меньше единицы.\nОно может рухнуть с минуты на минуту. Попробуйте изменить количество этажей к добавлению (например, на 0)\n");
				floorAmount = floorAmount - floorsToAdd;
				addFloors();
			}
			else
			{
				Console.WriteLine("Отлично! Здание получилось устойчивым с коэффициентом устойчивости k = " + stabilityFactor + "\n");
				// Отображение информации о здании.
				getBuilding();
			}
		}

		/* Функция по удалению floorsToRemove этажей у экземпляра класса Building. */
		public void removeFloors()
		{
			int floorsToRemove;
			// Защита от дурака для ввода floorsToRemove.
			Console.Write("Введите количество этажей для удаления с вашего здания: ");
			while (!int.TryParse(Console.ReadLine(), out floorsToRemove) || floorsToRemove < 0 || floorsToRemove >= floorAmount)
			{
				Console.Write("Неверный ввод количества - оно должно быть неотрицательным целым числом и меньшим общего числа этажей. Попробуйте еще раз: ");
			}
			// Расчет нового коэффициента устойчивости.
			floorAmount = floorAmount - floorsToRemove;
			stabilityFactor = (float)(sideLength * sideLength * Math.Sqrt(basementHeight)) / (floorHeight * floorAmount);
			Console.WriteLine("Этажи успешно удалены!");
			// Отображение информации о здании.
			getBuilding();
		}

		public void openWindowsOnFacade()
		{
			facade.openWindows();
			getBuilding();
		}

		public void closeWindowsOnFacade()
		{
			facade.closeWindows();
			getBuilding();
		}
	}
}
