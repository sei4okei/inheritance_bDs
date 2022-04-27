using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace inheritance_bDs
{
    internal class Menu
    {
        static void Main(string[] args)
        {
            WriteLine("Введите команду:\n0. Выход\n1. Добавить машину\n2. Добавить самолет\n3. Подсчитать налог с регистрации всех машин\n4. Подсчитать налог с регистрации всех самолетов\n5. Прошла ли самая дорогая машина техосмотр\n6. Найти мощность стоимость и марку самого дорогого самолета\n7. Найти мощность и макс. высоту для самолета\n8. Найти стоимость и пробег для машины\n9. Просмотр данных");
            while (true)
            {
                switch (Convert.ToInt32(CheckInput()))
                {
                    case 0:
                        Environment.Exit(0);
                        break;

                    case 1:
                        AddNewCar();
                        break;

                    case 2:
                        AddNewPlane();
                        break;

                    case 3:
                        ReadRegTaxCars();
                        break;

                    case 4:
                        ReadRegTaxPlanes();
                        break;

                    case 5:
                        CheckTechInspMostExpCar();
                        break;

                    case 6:
                        ReadMostExpPlane();
                        break;

                    case 7:
                        ReadPlanePowAlt();
                        break;

                    case 8:
                        ReadCarCostMile();
                        break;

                    case 9:
                        ReadAllRecords();
                        break;

                    default:
                        break;
                }
            }
        }

        static double CheckInput()
        {
            double UserInput;

            while (true)
            {
                try
                {
                    return UserInput = Convert.ToDouble(ReadLine());
                }
                catch (Exception)
                {
                    WriteLine("Что-то пошло не так, попробуйте снова!");
                }
            }
        }

        static void AddNewCar()
        {
            Write("Введите мощность: "); var power = Convert.ToInt32(CheckInput());
            Write("Введите стоимсоть: "); var cost = CheckInput();
            Write("Введите номер: "); var number = Convert.ToInt32(CheckInput());
            Write("Введите марку: "); var brand = ReadLine();
            Write("Введите пробег: "); var mileage = Convert.ToInt32(CheckInput());
            bool isTechInspPassed;
            while (true)
            {
                Write("Введите пройден ли тех. осмотр (да/нет): "); var TechInspPassed = ReadLine();
                if (TechInspPassed.ToLower() == "да")
                {
                    isTechInspPassed = true;
                    break;
                }
                else if (TechInspPassed.ToLower() == "нет")
                {
                    isTechInspPassed = false;
                    break;
                }
                else
                {
                    WriteLine("Введены неверные данные, попробуйте снова!");
                }
            }
            Transport.CreateCar(power, cost, number, brand, mileage, isTechInspPassed);
        }

        static void AddNewPlane()
        {
            Write("Введите мощность: "); var power = Convert.ToInt32(CheckInput());
            Write("Введите стоимсоть: "); var cost = CheckInput();
            Write("Введите номер: "); var number = Convert.ToInt32(CheckInput());
            Write("Введите марку: "); var brand = ReadLine();
            Write("Введите максимальную высоту: "); var maxAltitude = Convert.ToInt32(CheckInput());
            Transport.CreatePlane(power, cost, number, brand, maxAltitude);
        }

        static void ReadAllRecords()
        {
            Write($"Номер\tМарка\t\tМощность\tСтоимость\tПробег\tТех. осмотр");
            foreach (var car in Transport.cars)
            {
                WriteLine();
                Write($"{car.number}\t{car.brand}\t{car.power}\t\t{car.cost}\t\t{car.mileage}\t{car.isTechInspPassed}");
                WriteLine();
            }
            Write($"Номер\tМарка\t\tМощность\tСтоимость\tМакс. высота");
            foreach (var plane in Transport.planes)
            {
                WriteLine();
                Write($"{plane.number}\t{plane.brand}\t{plane.power}\t\t{plane.cost}\t\t{plane.maxAltitude}");
                WriteLine();
            }
        }

        static void ReadRegTaxCars()
        {
            WriteLine("Налог с регистрации всех машин = " + Transport.CalculateRegTaxCars());
        }

        static void ReadRegTaxPlanes()
        {
            WriteLine("Налог с регистрации всех  самолетов = " + Transport.CalculateRegTaxPlanes());
        }

        static void CheckTechInspMostExpCar()
        {
            if (Transport.ifMostExpCarPassedTechInsp())
            {
                WriteLine("Да, владелец самой дорогой машины прошел тех. осмотр");
            }
            else
            {
                WriteLine("Нет, владелец самой дорогой машины не прошел тех. осмотр");
            }
        }

        static void ReadMostExpPlane()
        {
            var plane = Transport.FindPlane(Transport.MostExpPlane());

            WriteLine("Мощность самого дорогого самолета: " + plane.power);
            WriteLine("Стоимость самого дорогого самолета: " + plane.cost);
            WriteLine("Марку самого дорогого самолета: " + plane.brand);
        }

        static int InputNum()
        {
            WriteLine("Введите номер: ");
            return Convert.ToInt32(CheckInput());
        }

        static void ReadPlanePowAlt()
        {
            Plane plane = Transport.FindPlane(InputNum());
            WriteLine("Мощность самолета : " + plane.power);
            WriteLine("Максимальная высота полета самолета : " + plane.maxAltitude);
        }

        static void ReadCarCostMile()
        {
            Car car = Transport.FindCar(InputNum());
            WriteLine("Стоимость машины : " + car.cost);
            WriteLine("Пробег машины : " + car.mileage);
        }
    }
}
