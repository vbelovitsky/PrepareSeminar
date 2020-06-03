using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_Lib
{
	public class Circle
	{

		Dot center;
		public Dot Center { get; set; }

		double radius;
		public double Radius
		{
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("Значение радиуса не может быть отрицательным");
				}
				radius = value;
			}
			get
			{
				return radius;
			}
		}

		public double Xmin()
		{
			return Center.X - Radius;
		}

		public double Xmax()
		{
			return Center.X + Radius;
		}


		public Circle(Dot center, double radius)
		{
			Center = center;
			Radius = radius;

			Center.XChanged += ChangeHandler;
		}

		public void ChangeHandler(double newX)
		{
			Console.WriteLine($"Минимальная координата: {Xmin()}");
			Console.WriteLine($"Максимальная координата: {Xmax()}");
		}
	}
}
