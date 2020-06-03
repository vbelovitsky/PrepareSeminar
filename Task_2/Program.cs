using System;
using System.IO;
using Task_2_Lib;

namespace Task_2
{
	class Program
	{
		static Random rnd = new Random();

		static string fileName = "bytes.bin";

		static bool GenerateFile()
		{
			try
			{
				byte[] bytes = new byte[1000];
				for (int i = 0; i < bytes.Length; i++)
				{
					bytes[i] = (byte)rnd.Next(0, 128);
				}

				File.WriteAllBytes(fileName, bytes);

				return true;
			}
			catch (IOException e)
			{
				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return false;
		}

		static bool FileProcessing(params LimitedSimbolChain[] chains)
		{
			if (File.Exists(fileName))
			{
				try
				{
					foreach (byte b in File.ReadAllBytes(fileName))
					{
						foreach (LimitedSimbolChain chain in chains)
						{
							if (b >= chain.StartCode && b <= chain.EndCode)
							{
								chain.AddToChain((char)b);
								break;
							}
						}
					}
					return true;
				}
				catch (IOException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (ArgumentOutOfRangeException e)
				{
					Console.WriteLine(e.Message);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return false;
		}

		static void Main(string[] args)
		{
			do
			{
				Console.Clear();

				Console.WriteLine(GenerateFile() ? "Файл сгенерирован" : "Файл не сгенерирован");

				LimitedSimbolChain latinLowerCaseChain = new LimitedSimbolChain('a', 'z', "Latin lowerCase");
				LimitedSimbolChain digitChain = new LimitedSimbolChain('0', '9', "Digits");
				LimitedSimbolChain latinUpperCaseChain = new LimitedSimbolChain('A', 'Z', "Latin upperCase");

				Console.WriteLine(FileProcessing(latinLowerCaseChain, digitChain, latinUpperCaseChain) ?
					"Файл успешно обработан" : "Файл не обработан");
				

				Console.WriteLine(latinLowerCaseChain.ToString());
				Console.WriteLine(digitChain.ToString());
				Console.WriteLine(latinUpperCaseChain.ToString());

				Console.Write("Для выхода нажмите Esc: ");
			}
			while (Console.ReadKey(true).Key != ConsoleKey.Escape);
		}
	}
}
