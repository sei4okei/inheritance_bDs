using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance_bDs
{
    internal class Transport
    {

        public int power { get; set; }
        public double cost { get; set; }
        public int number { get; set; }
        public string brand { get; set; }
        public static List<Car> cars = new List<Car>();
        public static List<Plane> planes = new List<Plane>();

        public static void CreateCar (int _power, double _cost, int _number, string _brand, int _mileage, bool _isTechInspPassed)
        {
            var car = new Car
            {
                power = _power,
                cost = _cost,
                number = _number,
                brand = _brand,
                mileage = _mileage,
                isTechInspPassed = _isTechInspPassed
            };
            cars.Add(car);
        }

        public static void CreatePlane(int _power, double _cost, int _number, string _brand, int _maxAltitude)
        {
            var plane = new Plane
            {
                power = _power,
                cost = _cost,
                number = _number,
                brand = _brand,
                maxAltitude = _maxAltitude
            };
            planes.Add(plane);
        }

        public static double CalculateRegTaxCars()
        {
            double Tax = 0;
            foreach (var car in cars)
            {
                Tax += car.cost * 0.05;
            }
            return Tax;
        }

        public static double CalculateRegTaxPlanes()
        {
            double Tax = 0;
            foreach (var plane in planes)
            {
                Tax += plane.cost * 0.03;
            }
            return Tax;
        }

        public static int MostExpCar()
        {
            double expCarCost = 0;
            int expCarNum = 0;
            foreach (var car in cars)
            {
                if (car.cost > expCarCost)
                {
                    expCarCost = car.cost;
                    expCarNum = car.number;
                }
            }
            return expCarNum;
        }

        public static int MostExpPlane()
        {
            double expPlaneCost = 0;
            int expPlaneNum = 0;
            foreach (var plane in planes)
            {
                if (plane.cost > expPlaneCost)
                {
                    expPlaneCost = plane.cost;
                    expPlaneNum = plane.number;
                }
            }
            return expPlaneNum;
        }

        public static bool ifMostExpCarPassedTechInsp()
        {
            foreach (var car in cars)
            {
                if (car.number == MostExpCar())
                {
                    if (car.isTechInspPassed == true)
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }

        public static Plane FindPlane(int planeNum)
        {
            foreach (var plane in planes)
            {
                if (plane.number == planeNum)
                {
                    return plane;
                }
            }
            return null;
        }

        public static Car FindCar(int carNum)
        {
            foreach (var car in cars)
            {
                if (car.number == carNum)
                {
                    return car;
                }
            }
            return null;
        }
    }
}
