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
			RunMainMenu();
		}

		public void RunMainMenu()
		{
			string prompt = @"
 __                                                __            
(_ |_    _| _ _ |_  |\/| _  _  _  _  _ _  _ _ |_  (_    _|_ _ _  
__)|_|_|(_|(-| )|_  |  |(_|| )(_|(_)(-|||(-| )|_  __)\/_)|_(-||| 
                                 _/                  /           
Welcome to the Student Management System ! What would you like to do ?
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
			Console.WriteLine("<< Add User >>");
			Console.WriteLine("First Name: ");
			string fname="", lname="", dob = "", address = "", modules_indexes = "";
			try
			{
				fname = Console.ReadLine();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Last Name: ");
			try
			{
				lname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Date of Birth: ");
			try
			{
				dob = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Address:");
			try
			{
				address = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Modules enrolled (1:EE3301, 2:CE3201, 3:ME3305, 4:IS3201) . Enter them space separately (eg: 2 3):");
			try
			{
				modules_indexes = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}

			/*
			
			Create new user with -> fname,lname,dob,address

			get modules array for -> modules indexes
			
			insert those modules for 'user'

			update 'users' array

			 */
			User user = new User(fname,lname,dob,address);
			
			string[] modules_idxs = modules_indexes.Split(null);
			
			foreach(string mod in modules_idxs)
			{
				foreach(Module mod2 in modules)
				{
					if(mod==mod2.Id) user.Modules.Add(mod2);
				}
			}

			users.Add(user);

			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			RunMainMenu();
		}
		
		// Main Menu
		private void SelectUser()
		{
			string prompt = @"

<< Select User >>

";
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
			if (selectedIndex == options.Count - 1) RunMainMenu();
			else UserN(selectedIndex);
		}
		
		private void UserN(int idx)
		{
			string prompt = @"

<< User >>

";
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
			Console.WriteLine("<< Modify User >>");
			Console.WriteLine("First Name\t: ");
			string fname = "", lname = "", dob = "", address = "", modules_indexes = "";
			try
			{
				fname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Last Name\t: ");
			try
			{
				lname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Date of Birth\t: ");
			try
			{
				dob = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Address\t:");
			try
			{
				address = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Modules enrolled (1:EE3301, 2:CE3201, 3:ME3305, 4:IS3201) . Enter them space separately (eg: 2 3):");
			try
			{
				modules_indexes = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			/*
			
			Acess user by idx -->  User user = Users[idx];
			
			update 'user' details with -> fname,lname,dob,address

			update 'users' array
			
			*/

			users[idx].FirstName = fname;
			users[idx].LastName = lname;
			users[idx].DateOfBirth = dob;
			users[idx].Address = address;

			string[] modules_idxs = modules_indexes.Split(null);

			users[idx].Modules = new List<Module> { };
			foreach (string mod in modules_idxs)
			{
				foreach (Module mod2 in modules)
				{
					if (mod == mod2.Id) users[idx].Modules.Add(mod2);
				}
			}

			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			RunMainMenu();
		}
		// UserN Menu
		private void UserNAddModules(int idx)
		{
			Console.Clear();
			Console.WriteLine("<< Add Module >>");

			Console.WriteLine("Modules about to enroll (1:EE3301, 2:EE3305, 3:EE330, 4:IS3401). Enter them space separately (eg: 2 3):");
			string modules_indexes = "";
			try
			{
				modules_indexes = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			/*
			
			
			Acess 'user' by idx -->  User user = Users[idx];
			
			get modules array for -> 'modules_indexes'
			
			insert those modules for 'user'

			update 'users' array
			
			*/
			string[] modules_idxs = modules_indexes.Split(null);

			foreach (string mod in modules_idxs)
			{
				foreach (Module mod2 in modules)
				{
					if (mod == mod2.Id) users[idx].Modules.Add(mod2);
				}
			}

			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			RunMainMenu();


		}
		// UserN Menu
		private void UserNRemoveModules(int idx)
		{
			string prompt = @"

<< Remove Module >>

";
			// user 'Module' objects array of particular user
			List<Module> userModules = users[idx].Modules;
			List<string> options = new List<string> { };
			foreach (Module mod in userModules) { options.Add(mod.Name); }
			options.Add("Back to Main Menu");
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();
			if (selectedIndex == options.Count - 1) RunMainMenu();
			else users[idx].Modules.RemoveAt(selectedIndex);
			/*
			 remove selecedIndex's module of given users , from his module array
			 */
			RunMainMenu();

		}
		// UserN Menu
		private void UserNDeleteUser(int idx)
		{
			/*
			 
			access 'user' by 'idx'
			update 'users'
			
			*/
			users.RemoveAt(idx);
			RunMainMenu();

		}
		// UserN Menu
		private void UserNBack()
		{
			RunMainMenu();
		}



		// Main Menu
		private void DeleteUser()
		{
			string prompt = @"

<< Delete User >>

";
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
			if (selectedIndex != options.Count-1)
			{
				users.RemoveAt(selectedIndex);
			}
			RunMainMenu();
		}
		// Main Menu
		private void DisplayAllUsers()
		{
			Console.Clear();

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


			Console.WriteLine("FirstName\tLastName\tDateOfBirth\tAddress\tModules");
			foreach (User user in users)
			{
				string modules_str = "";
				foreach(Module mod in user.Modules)
				{
					modules_str += mod.Name;
					modules_str += " ";
				}

				Console.WriteLine($"{user.FirstName}\t{user.LastName}\t{user.DateOfBirth}\t{user.Address}\t{modules_str}");
			}



			Console.WriteLine("\npress any key to go back to main menu...");
			Console.ReadKey(true);
			RunMainMenu();
		}
		// Main Menu
		private void Quit()
		{

			Console.WriteLine("\npress any key to Quit...");
			Console.ReadKey(true);
			Environment.Exit(0);
		}
	}
}
