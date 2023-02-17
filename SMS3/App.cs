using CSharpBasics.TabularData;
using Microsoft.Extensions.Options;
using SMS3.ForPrintTable;
using SMS3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace SMS3
{
    public class App
	{
		public List<User> users { get; set; }
		public List<Module> modules { get; set; }

		public App()
		{
			Module m1 = new Module("1","EE3301","3");
			Module m2 = new Module("2", "CE3201", "2");
			Module m3 = new Module("3", "ME3305", "3");
			Module m4 = new Module("4", "IS3201", "2");
			users = new List<User> { };
			modules = new List<Module> { m1, m2, m3, m4};
		}

		public void Start()
		{
			Console.Title = "Student Management System";
			Console.CursorVisible = false;
			Console.Clear();
			RunMainMenu();
		}

		public void RunMainMenu()
		{
			string prompt = @"

█▀ ▀█▀ █░█ █▀▄ █▀▀ █▄░█ ▀█▀   █▀▄▀█ ▄▀█ █▄░█ ▄▀█ █▀▀ █▀▀ █▀▄▀█ █▀▀ █▄░█ ▀█▀   █▀ █▄█ █▀ ▀█▀ █▀▀ █▀▄▀█
▄█ ░█░ █▄█ █▄▀ ██▄ █░▀█ ░█░   █░▀░█ █▀█ █░▀█ █▀█ █▄█ ██▄ █░▀░█ ██▄ █░▀█ ░█░   ▄█ ░█░ ▄█ ░█░ ██▄ █░▀░█


Welcome to the Student Management System !

(Use the arrow keys to cycle through options and press enter to select an option.)

";
			
			List<string> options = new List<string> { "Add User", "Select User", "Delete User","Display All Users","Quit" };
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();

			switch (selectedIndex)
			{
				case 0:
					AddUser();
					break;
				case 1:
					SelectUser();
					break;
				case 2:
					DeleteUser();
					break;
				case 3:
					DisplayAllUsers();
					break;
				case 4:
					Quit();
					break;
			}
		}

		// Main Menu
		private void AddUser()
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("<< Add User >>");
			Console.ResetColor();
			Console.CursorVisible = true;
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("\n> First Name: ");
			Console.ResetColor();
			string fname="", lname="", dob = "", address = "";
			List<string> modules_idxs = new List<string> { };
			try
			{
				Console.ForegroundColor = ConsoleColor.Green;
				fname = Console.ReadLine();
				Console.ResetColor();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("\n> Last Name: ");
			Console.ResetColor();
			try
			{
				Console.ForegroundColor = ConsoleColor.Green;
				lname = Console.ReadLine();
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("\n> Date of Birth (should be DD/MM/YYYY format): ");
			Console.ResetColor();
			try
			{
				Console.ForegroundColor = ConsoleColor.Green;
				dob = Console.ReadLine();
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine("\n> Address:");
			Console.ResetColor();
			try
			{
				Console.ForegroundColor = ConsoleColor.Green;
				address = Console.ReadLine();
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}

			/*
			Console.WriteLine("Modules enrolled (1:EE3301, 2:CE3201, 3:ME3305, 4:IS3201) . Enter them space separately (eg: 2 3):");
			try
			{
				modules_indexes = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}*/
			Console.CursorVisible = false;
			
			string propmpt = "\n> Available Modules :";
			List<string> options = new List<string> {};
			foreach(Module mod in modules) options.Add(mod.Name);
			options.Add(" Finish Selections :-) ");
			Menu menu = new Menu(propmpt, options);
			var cursorPos = Console.GetCursorPosition();
			List<int> selectedIndexes = menu.RunWithoutClearConsole(cursorPos);
			foreach(int index in selectedIndexes) modules_idxs.Add(index.ToString());


			/*
			
			Create new user with -> fname,lname,dob,address

			get modules array for -> modules indexes
			
			insert those modules for 'user'

			update 'users' array

			 */
			// check wheter 'dob' in DD/MM/YYYY format
			if (dob.Length != 10) dob = "Not Valid";
			User user = new User(fname,lname,dob,address);
			
			foreach(string mod in modules_idxs)
			{
				foreach(Module mod2 in modules)
				{
					if(mod==mod2.Id) user.Modules.Add(mod2);
				}
			}

			if (user.Modules.Count > 0)
			{

				string gradePointValuesInstructions = @"

	+---------------------+
	| Grade Point Values  |
	+----------+----------+
	| A = 4.0  | C+ = 2.3 |
	+----------+----------+
	| A- = 3.7 | C = 2.0  |
	+----------+----------+
	| B+ = 3.3 | C- = 1.7 |
	+----------+----------+
	| B = 3.0  | F = 0    |
	+----------+----------+
	| B- = 2.7 |          |
	+----------+----------+

Choose your grade (eg:- A-)
Note : If you didn't mention your grade, it will account as 'F' !
";

				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine("\n> Enter your grades for each module : " + gradePointValuesInstructions);
				Console.ResetColor();

				Console.CursorVisible = true;
				string grade = "";
				string[] grades_ = { "A" ,"A-","B+","B","B-","C+","C","C-","F"};

				foreach (Module mod in user.Modules)
				{

					Console.ForegroundColor = ConsoleColor.DarkCyan;
					Console.WriteLine("> " + mod.Name + " : ");

					Console.ForegroundColor = ConsoleColor.Green;
					grade = Console.ReadLine().ToUpper();
					Console.ResetColor();

					if (grades_.Contains(grade)) mod.GradePoint = grade;
					else mod.GradePoint = "F";
				}
			}



			// to make first name mandatory
			if (fname!="") users.Add(user);

			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			Console.Clear();
			RunMainMenu();
		}
		
		// Main Menu
		private void SelectUser()
		{
			string prompt = "<< Select User >>\n";
			// user 'Users' objects array
			List<string> options = new List<string> { };
			foreach (User user_ in users)
			{
				options.Add(user_.FirstName + " " + user_.LastName);
			}
			options.Add("Back to Main Menu");
			//List<string> options = new List<string> {"User 1", "User 2", "User 3"};
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();
			if (selectedIndex == options.Count - 1)
			{
				Console.Clear();
				RunMainMenu();
			}
			else UserN(selectedIndex);
		}
		
		private void UserN(int idx)
		{
			string prompt = "<< User >>\n";
			List<string> options = new List<string> { "Modify User","Add Modules","Remove Modules","Delete User","Back" };
			Menu menu = new Menu(prompt,options);
			int selectedIndex = menu.Run();
			switch(selectedIndex)
			{
				case 0:
					UserNModifyUser(idx);
					break;
				case 1:
					UserNAddModules(idx);
					break;
				case 2:
					UserNRemoveModules(idx);
					break;
				case 3:
					UserNDeleteUser(idx);
					break;
				case 4:
					UserNBack();
					break;
			}
		}

		// UserN Menu
		private void UserNModifyUser(int idx)
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("<< Modify User >>\n(press Enter if you don't want to change)\n");
			Console.ResetColor();


			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine($"\n> First Name ({users[idx].FirstName})\t: ");
			Console.ResetColor();

			string fname = "", lname = "", dob = "", address = "";
			List<string> modules_idxs = new List<string> { };
			try
			{
				fname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine($"\n> Last Name ({users[idx].LastName})\t: ");
			Console.ResetColor();
			try
			{
				lname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine($"\n> Date of Birth ({users[idx].DateOfBirth})\t: ");
			Console.ResetColor();
			try
			{
				dob = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine($"\n> Address ({users[idx].Address})\t:");
			Console.ResetColor();
			try
			{
				address = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			/*
			Console.WriteLine("> Modules enrolled (1:EE3301, 2:CE3201, 3:ME3305, 4:IS3201) . Enter them space separately (eg: 2 3):");
			try
			{
				modules_indexes = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			*/

			string propmpt = "Available Modules :";

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.Write("\n(....You already enrolled to -> ");
			if (users[idx].Modules.Count == 0) Console.WriteLine("Nothing :-|");
			foreach (Module mod in users[idx].Modules) Console.Write(mod.Name + " ");
			Console.WriteLine("....)\n");
			Console.ResetColor();


			List<string> options = new List<string> { };
			foreach (Module mod in modules) if (!users[idx].Modules.Contains(mod)) options.Add(mod.Name);
			options.Add(" Finish Selections :-) ");
			Menu menu = new Menu(propmpt, options);
			var cursorPos = Console.GetCursorPosition();
			List<int> selectedIndexes = menu.RunWithoutClearConsole(cursorPos);
			foreach (int index in selectedIndexes) modules_idxs.Add(index.ToString());

			/*
			
			Acess user by idx -->  User user = Users[idx];
			
			update 'user' details with -> fname,lname,dob,address

			update 'users' array
			
			*/

			if(fname!="") users[idx].FirstName = fname;
			if (lname != "") users[idx].LastName = lname;
			if (dob != "") users[idx].DateOfBirth = dob;
			if (address != "") users[idx].Address = address;

			List<Module> remainModules = new List<Module> { };
			foreach (Module mod in modules) if (!users[idx].Modules.Contains(mod)) remainModules.Add(mod);
			for(int i = 0; i < remainModules.Count; i++)
			{
				remainModules[i].Id = (i + 1).ToString();
			}

			int newlyAddedModules = 0;
			foreach (string mod in modules_idxs)
			{
				foreach (Module mod2 in remainModules)
				{
					if ((mod == mod2.Id) && (!users[idx].Modules.Contains(mod2)))
					{
						newlyAddedModules++;
						mod2.GradePoint = "";
						users[idx].Modules.Add(mod2);
					}
				}
			}


			if (newlyAddedModules > 0)
			{

				string gradePointValuesInstructions = @"

	+---------------------+
	| Grade Point Values  |
	+----------+----------+
	| A = 4.0  | C+ = 2.3 |
	+----------+----------+
	| A- = 3.7 | C = 2.0  |
	+----------+----------+
	| B+ = 3.3 | C- = 1.7 |
	+----------+----------+
	| B = 3.0  | F = 0    |
	+----------+----------+
	| B- = 2.7 |          |
	+----------+----------+

Choose your grade (eg:- A-)
Note : If you didn't mention your grade, it will account as 'F' !
";

				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine("\n> Enter your grades for each module : " + gradePointValuesInstructions);
				Console.ResetColor();

				Console.CursorVisible = true;
				string grade = "";
				string[] grades_ = { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "F" };
				
				foreach (Module mod in users[idx].Modules)
				{
					if (mod.GradePoint.Length == 0)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("> " + mod.Name + " : ");
						Console.ResetColor();

						grade = Console.ReadLine().ToUpper();
						if (!grades_.Contains(grade)) mod.GradePoint = grade;
						else mod.GradePoint = "F";
					}
				}

			}


			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			Console.Clear();
			RunMainMenu();
		}
		// UserN Menu
		private void UserNAddModules(int idx)
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("<< Add Module >>");
			Console.ResetColor();

			/*
			Console.WriteLine("\nModules about to enroll (1:EE3301, 2:EE3305, 3:EE330, 4:IS3401). Enter them space separately (eg: 2 3):");
			string modules_indexes = "";
			try
			{
				modules_indexes = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			*/

			string propmpt = "Available Modules :";

			Console.Write("\n(....You already enrolled to -> ");
			if (users[idx].Modules.Count == 0) Console.WriteLine("Nothing :-|");
			foreach (Module mod in users[idx].Modules) Console.Write(mod.Name + " ");
			Console.WriteLine("....)\n");

			List<string> modules_idxs = new List<string> { };
			List<string> options = new List<string> { };
			foreach (Module mod in modules) if (!users[idx].Modules.Contains(mod)) options.Add(mod.Name);
			options.Add(" Finish Selections :-) ");
			Menu menu = new Menu(propmpt, options);
			var cursorPos = Console.GetCursorPosition();
			List<int> selectedIndexes = menu.RunWithoutClearConsole(cursorPos);
			foreach (int index in selectedIndexes) modules_idxs.Add(index.ToString());


			/*
			
			Acess 'user' by idx -->  User user = Users[idx];
			
			get modules array for -> 'modules_indexes'
			
			insert those modules for 'user'

			update 'users' array
			
			*/
			List<Module> remainModules = new List<Module> { };
			foreach (Module mod in modules) if (!users[idx].Modules.Contains(mod)) remainModules.Add(mod);
			for (int i = 0; i < remainModules.Count; i++)
			{
				remainModules[i].Id = (i + 1).ToString();
			}

			int newlyAddedModules = 0;
			foreach (string mod in modules_idxs)
			{
				foreach (Module mod2 in remainModules)
				{
					if ((mod == mod2.Id) && (!users[idx].Modules.Contains(mod2)))
					{
						newlyAddedModules++;
						mod2.GradePoint = "";
						users[idx].Modules.Add(mod2);
					}
				}
			}

			if (newlyAddedModules>0)
			{
				string gradePointValuesInstructions = @"

	+---------------------+
	| Grade Point Values  |
	+----------+----------+
	| A = 4.0  | C+ = 2.3 |
	+----------+----------+
	| A- = 3.7 | C = 2.0  |
	+----------+----------+
	| B+ = 3.3 | C- = 1.7 |
	+----------+----------+
	| B = 3.0  | F = 0    |
	+----------+----------+
	| B- = 2.7 |          |
	+----------+----------+

Choose your grade (eg:- A-)
Note : If you didn't mention your grade, it will account as 'F' !
";

				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine("\n> Enter your grades for each module : " + gradePointValuesInstructions);
				Console.ResetColor();

				Console.CursorVisible = true;
				string grade = "";
				string[] grades_ = { "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "F" };
				
				foreach (Module mod in users[idx].Modules)
				{
					if (mod.GradePoint.Length == 0)
					{

						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("> " + mod.Name + " : ");
						Console.ResetColor();

						grade = Console.ReadLine().ToUpper();
						if (grades_.Contains(grade)) mod.GradePoint = grade;
						else mod.GradePoint = "F";
					}
				}
			}



			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			Console.Clear();
			RunMainMenu();


		}
		// UserN Menu
		private void UserNRemoveModules(int idx)
		{
			string prompt = "<< Remove Modules >>\n";
			// user 'Module' objects array of particular user
			List<Module> userModules = users[idx].Modules;
			List<string> options = new List<string> { };
			foreach (Module mod in userModules) { options.Add(mod.Name); }
			options.Add("Back to Main Menu");
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\nAre you sure ? do you want to delete this user ? (press 'y' if yes / press any other to go back main menu)");
			Console.ResetColor();

			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			ConsoleKey keyPressed = keyInfo.Key;


			if (keyPressed == ConsoleKey.Y)
			{
				if (selectedIndex != options.Count - 1) users[idx].Modules.RemoveAt(selectedIndex); ;
			}

			/*
			 remove selecedIndex's module of given users , from his module array
			 */
			Console.Clear();
			RunMainMenu();

		}
		// UserN Menu
		private void UserNDeleteUser(int idx)
		{
			/*
			 
			access 'user' by 'idx'
			update 'users'
			
			*/


			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\nAre you sure ? do you want to delete this user ? (press 'y' if yes / press any other to go back main menu)");
			Console.ResetColor();

			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			ConsoleKey keyPressed = keyInfo.Key;

			if (keyPressed == ConsoleKey.Y) users.RemoveAt(idx);
			Console.Clear();
			RunMainMenu();

		}
		// UserN Menu
		private void UserNBack()
		{
			Console.Clear();
			RunMainMenu();
		}


		// Main Menu
		private void DeleteUser()
		{
			string prompt = "<< Delete User >>\n";
			// user 'Users' objects array
			List<string> options = new List<string> { };
			foreach (User user_ in users)
			{
				options.Add(user_.FirstName + " " + user_.LastName);
			}
			options.Add("Back to Main Menu");

			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();

			/*
			
			access 'user' by 'selectedIndex'

			remove 'user' from 'users' array

			 */

			if (users.Count > 0)
			{

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\nAre you sure ? do you want to delete this user ? (press 'y' if yes / press any other to go back main menu)");
				Console.ResetColor();
			}
			else Console.WriteLine("press any other to go back main menu ...");

			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			ConsoleKey keyPressed = keyInfo.Key;
			
			if(keyPressed == ConsoleKey.Y ) {
				if (selectedIndex != options.Count - 1)
				{
					users.RemoveAt(selectedIndex);
				}
			}
			Console.Clear();
			RunMainMenu();
		}
		// Main Menu
		private void DisplayAllUsers()
		{
			Console.Clear();


			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("<< Delete User >>\n");
			Console.ResetColor();
			/*
			
				
				foreach(User user : Users){
					string modules_str="";
					foreach(Module mod:user.modules){
						modules_str += mod.Name;
						modules_str += " "; 
					}
					Console.WriteLine($"{user.FirstName}\t{user.LastName}\t{user.DateOfBirth}\t{user.Address}\t{modules_str}")
				}

			 */


			IPrintTabularData<TempUser> userDataPrinter = new TablePrinter<TempUser>();

			// for purpose of drawing the table
			List<TempUser> tempUsers = new List<TempUser>();
			
			foreach(User u in users)
			{
				TempUser tu = new TempUser();
				tu.FirstName = u.FirstName;
				tu.LastName = u.LastName;
				tu.DateOfBirth = u.DateOfBirth;
				tu.GPA = Math.Round(CalcGPA(u),3).ToString();
				tempUsers.Add(tu);
			}

			userDataPrinter.PrintTable(tempUsers);



			//Console.WriteLine("FirstName\tLastName\tDateOfBirth\tAddress\t\t\tModules\t\t\tGPA");
			//foreach (User user in users)
			//{
			//	string modules_str = "";
			//	foreach(Module mod in user.Modules)
			//	{
			//		modules_str += mod.Name;
			//		modules_str += " ";
			//	}
			//	double GPA=CalcGPA(user);
			//	Console.WriteLine($"{user.FirstName}\t\t{user.LastName}\t\t{user.DateOfBirth}\t{user.Address}\t\t{modules_str}\t{GPA}");
			//}



			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			Console.Clear();
			RunMainMenu();
		}
		// Main Menu
		double CalcGPA(User user)
		{
			var grades = new Dictionary<string, double>()
			{
				{"A",4.0 },
				{"A-",3.7 },
				{"B+",3.3 },
				{"B",3.0 },
				{"B-",2.7 },
				{"C+",2.3 },
				{"C",2.0 },
				{"C-",1.7 },
				{"F",0 }
			}; 
			double GPA=0,TotalCredits=0,EarnedCredits=0;
			foreach(Module mod in user.Modules)
			{
				double modCredVal = Convert.ToDouble(mod.CreditValue);
				TotalCredits += modCredVal;
				EarnedCredits += modCredVal * grades[mod.GradePoint] / 4;
			}
			GPA = (EarnedCredits / TotalCredits) * 4;
			return GPA;
		}
		private void Quit()
		{

			Console.WriteLine("\npress any key to Quit...");
			Console.ReadKey(true);
			Environment.Exit(0);
		}
	}
}
