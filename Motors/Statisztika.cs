using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors
{
	internal class Statisztika
	{
		List<Motor>motors = [];
		
		public void ReadFromFile(string fileName)
		{
			StreamReader sr = new StreamReader(fileName);
			sr.ReadLine();


			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine() ?? ""; //ez a zöld vonal azért van, mert lehet lesz benne null érték, és a ?? "" az azért van hogy tudja mit tegyen ha mégis null lenne
				string[] szavak = sor.Split(';');

				Motor ujMotor = new(szavak[0], szavak[1], Convert.ToInt16(szavak[2]), Convert.ToDouble(szavak[3]), Convert.ToDouble(szavak[4]));

				motors.Add(ujMotor);

				//motors.Add(new Motor(és ide írom azt a sokat));  így is meg lehet csinálni
			}
		}


		public int sumPrices()
		{
			double sum = 0;

			for (int i = 0; i < motors.Count; i++) //ha egy osztályon belül dolgozunk, akkor aminót fent megadunk azt mindhol lehet látni
			{
				sum += motors[i].PriceInEuro; //double volt a price 
			}
			return (int)sum; //igy is lehet int-té convertélni, csak erre a sorra érvényes, nem konvertálja véglegesen át, a coverttoint meg végleges
		}


		public bool Contains (string motorName)
		{
			bool isThere = false;
			for (int i = 0; i < motors.Count; i++)
			{
				if (motors[i].Name == motorName) isThere = true;	
			}
			return isThere;
		}

		public Motor Oldest()
		{
			Motor oldestMotor = motors[0];
			for (int i = 1; i < motors.Count; i++)
			{
				if (oldestMotor.ReleaseYear > motors[i].ReleaseYear)
				{
					oldestMotor = motors[i];
				}
			}
			return oldestMotor;
		}

		public int SumBasedOnBrand(string brandName, string filename)
		{
			List<Motor> brandMotors = new List<Motor>();
			for (int i = 0;i < motors.Count; i++)
			{
				if (motors[i].Brand == brandName)
				{
					brandMotors.Add(motors[i]);
				}
			}
			motors = brandMotors;
			int sum = this.sumPrices();

			motors.Clear();
			this.ReadFromFile(filename);

			return sum;
		}

		public void Sort()
		{
			Console.WriteLine("A motorok teljesítmény alapján rendezése: ");
			for (int i = motors.Count; i > 0; i--)
			{
				for (int j = 0; j < motors.Count-1; j++)
				{
					if (motors[j].Performance < motors[j+1].Performance)
					{
						Motor temp = motors[j];
						motors[j] = motors[j+1];
						motors[j+1] = temp;
					}
				}
			}
			for (int i = 0; i < motors.Count; i++)
			{
                
                Console.WriteLine(motors[i].Brand +" " + motors[i].Name + " eljesítménye: " + motors[i].Performance);
            }
		}

	}
}
