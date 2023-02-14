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
		public string[] Options { get; set; }
		public int SelectedIndex { get; set; }

		public Menu(string prompt, string[] options)
		{
			Prompt = prompt;
			Options = options;
			SelectedIndex = 0;
		}

		private void DisplayOptions()
		{
			Console.WriteLine(Prompt);
			for (int i = 0; i < Options.Length; i++)
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
						if (SelectedIndex < 0) SelectedIndex = Options.Length - 1;
						break;

					case ConsoleKey.DownArrow:
						SelectedIndex++;
						if (SelectedIndex == Options.Length) SelectedIndex = 0;
						break;
				}

			} while (keyPressed != ConsoleKey.Enter);

			return SelectedIndex;
		}
	}
}
