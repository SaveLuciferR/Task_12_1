using System;

namespace Task_11_1
{
	class Array
	{
		private double[][] doubleArray;
		private int n, m;

		public int countArray
		{
			get
			{
				return n * m;
			}
		}
		public int scalarArray
		{
			set
			{
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						doubleArray[i][j] += value;
					}
				}
			}
		}

		public double this[int i, int j]
		{
			get
			{
				return doubleArray[i][j];
			}
			set
			{
				doubleArray[i][j] = value;
			}
		}

		public Array(int n, int m)
		{
			this.n = n;
			this.m = m;
			doubleArray = new double[n][];
			for (int i = 0; i < n; i++)
			{
				doubleArray[i] = new double[m];
			}
		}

		public void SetArrayElement()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					doubleArray[i][j] = Convert.ToDouble(Console.ReadLine());
				}
			}
		}

		public void GetArrayElement()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					Console.Write(doubleArray[i][j] + "\t");
				}
				Console.WriteLine();
			}
		}

		public void SortArrayElement()
		{
			for (int i = 0; i < n; i++)
			{
				for (int k = 0; k < m; k++)
				{
					for (int j = 0; j < m - 1; j++)
					{
						if (doubleArray[i][j] < doubleArray[i][j + 1])
						{
							double temp = doubleArray[i][j];
							doubleArray[i][j] = doubleArray[i][j + 1];
							doubleArray[i][j + 1] = temp;
						}
					}
				}
			}
		}

		private bool checkSortArray ()
		{
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m - 1; j++)
				{
					if (doubleArray[i][j] > doubleArray[i][j + 1])
					{
						return false;
					}
				}
			}

			return true;
		}

		public static Array operator ++ (Array array)
		{
			for (int i = 0; i < array.n; i++)
			{
				for (int j = 0; j < array.m; j++)
				{
					array.doubleArray[i][j]++;
				}
			}

			return array;
		}

		public static Array operator -- (Array array)
		{
			for (int i = 0; i < array.n; i++)
			{
				for (int j = 0; j < array.m; j++)
				{
					array.doubleArray[i][j]--;
				}
			}

			return array;
		}

		public static bool operator true (Array array)
		{
			return array.checkSortArray();
		}
		public static bool operator false (Array array)
		{
			return !array.checkSortArray();
		}

		public static Array operator * (Array array1, Array array2)
		{
			if (array1.m == array2.n)
			{
				int n = array1.n;
				int m = array2.m;
				Array arrRes = new Array(n, m);

				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < m; j++)
					{
						for (int k = 0; k < array1.m; k++)
						{
							arrRes.doubleArray[i][j] += (array1[i, k] * array2[k, j]);
						}
					}
				}
				return arrRes;
			}
			else
			{
				throw new Exception();
			}
		}

		public static implicit operator double[,](Array array)
		{
			double[,] temp = new double[array.n, array.m];

			for (int i = 0; i < array.n; i++)
			{
				for (int j = 0; j < array.m; j++)
				{
					temp[i, j] = array.doubleArray[i][j];
				}
			}

			return temp;
		}

		public static implicit operator Array(double[,] array)
		{
			var n = array.GetLength(0);
			var m = array.GetLength(1);
			var temp = new Array(n, m);

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < m; j++)
				{
					temp[i, j] = array[i, j];
				}
			}

			return temp;
		}
	}

	class Programm
	{
		static void Main()
		{
			try
			{
				Console.WriteLine("Введите размер массива");
				Console.Write("n = ");
				int n = Convert.ToInt32(Console.ReadLine());
				Console.Write("m = ");
				int m = Convert.ToInt32(Console.ReadLine());

				Array doubleArray = new Array(n, m);

				Console.WriteLine("\nВведите элементы массива");
				doubleArray.SetArrayElement();
				Console.WriteLine();
				doubleArray.GetArrayElement();
				Console.WriteLine("\nСортировка массива");
				//doubleArray.SortArrayElement();
				doubleArray.GetArrayElement();
				Console.Write("\nВведите скаляр: ");
				int scalar = Convert.ToInt32(Console.ReadLine());
				doubleArray.scalarArray = scalar;
				Console.WriteLine("\nМассив, умноженнй на скаляр");
				doubleArray.GetArrayElement();
				Console.WriteLine("\nКол-во элеметов в массиве: " + doubleArray.countArray);

				Console.WriteLine("\nВведите индекс i от 0 до {0} и j от 0 до {1}", (n - 1), (m - 1));
				Console.Write("i = ");
				int i = Convert.ToInt32(Console.ReadLine());
				Console.Write("j = ");
				int j = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine("\nПо индексу ({0}, {1}): {2}", i, j, doubleArray[i, j]);
				Console.WriteLine("\nУвеличение элементов массива на 1");
				doubleArray++;
				doubleArray.GetArrayElement();
				Console.WriteLine("\nУменьшение элементов массива на 1");
				doubleArray--;
				doubleArray.GetArrayElement();

				if (doubleArray)
				{
					Console.WriteLine("\nМассив упорядочен по возрастанию");
				}
				else
				{
					Console.WriteLine("\nМассив не упорядочен по возрастанию");
				}

				Console.WriteLine("Введите новый размер массива");
				Console.Write("n = ");
				int n2 = Convert.ToInt32(Console.ReadLine());
				Console.Write("m = ");
				int m2 = Convert.ToInt32(Console.ReadLine());
				Array doubleArray2 = new Array(n2, m2);
				Console.WriteLine("\nВведите элементы массива");
				doubleArray2.SetArrayElement();
				Console.WriteLine();
				doubleArray2.GetArrayElement();

				Array arrRes = doubleArray * doubleArray2;

				Console.WriteLine("\nРезультат умножения двух массивов");
				arrRes.GetArrayElement();
				Console.WriteLine("\n\n\nПреобразование в двумерный массив");
				Array arrResDouble = (Array)arrRes;
				arrResDouble.GetArrayElement();
				Console.WriteLine("\nПреобразование в ступеньчатый массив");
				arrResDouble = (double[,])arrResDouble;
				arrRes.GetArrayElement();
			}
			catch (FormatException)
			{
				Console.WriteLine("Введите верный формат");
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Неверный индекс массива");
			}
			catch
			{
				Console.WriteLine("Массивы не подходят для перемножения");
			}
		}
	}
}