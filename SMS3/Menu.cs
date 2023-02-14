using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS3
{
	public class Menu
	{
		public string Prompt { get; set; }
		public List<string> Options { get; set; }
		public int SelectedIndex { get; set; }

		public Menu(string prompt, List<string> options)
		{
			Prompt = prompt;
			Options = options;
			SelectedIndex = 0;
		}

		private void DisplayOptions()
		{
			Console.WriteLine(Prompt);
			for (int i = 0; i < Options.Count; i++)
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.Black;
				string prefix;

				if (i == SelectedIndex)
				{
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
					prefix = $"*";
				}
				else
				{
					prefix = " ";
				}
				string currentOption = Options[i];
				Console.WriteLine($"{prefix} << {currentOption} >>");
			}
			Console.ResetColor();
			Console.WriteLine("\nWatch my progress of project with source code :) https://github.com/PasanAbeysekara/StudentManagementSystem");
		}

		public int Run()
		{
			ConsoleKey keyPressed;
			do
			{
				Console.Clear();
				DisplayOptions();

				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				keyPressed = keyInfo.Key;

				switch (keyPressed)
				{
					case ConsoleKey.UpArrow:
						SelectedIndex--;
						if (SelectedIndex < 0) SelectedIndex = Options.Count - 1;
						break;

					case ConsoleKey.DownArrow:
						SelectedIndex++;
						if (SelectedIndex == Options.Count) SelectedIndex = 0;
						break;
				}

			} while (keyPressed != ConsoleKey.Enter);

			return SelectedIndex;
		}
	}
}
