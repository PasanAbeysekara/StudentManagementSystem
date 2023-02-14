using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS3
{
	public class App
	{
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

			string[] options = { "Add User", "Select User", "Delete User","Display All Users","Quit" };
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
			try
			{
				string fname = Console.ReadLine();
			}
			catch(Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Last Name: ");
			try
			{
				string lname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Date of Birth: ");
			try
			{
				string dob = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Address:");
			try
			{
				string address = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Modules enrolled (1:EE3301, 2:EE3305, 3:EE330, 4:IS3401) . Enter them space separately (eg: 2 3):");
			try
			{
				string modules_indexes = Console.ReadLine();
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
			string[] options = {"User 1", "User 2", "User 3"};
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();
			UserN(selectedIndex);

		}
		
		private void UserN(int idx)
		{
			string prompt = @"

<< User >>

";
			string[] options = { "Modify User","Add Modules","Remove Modules","Delete User","Back" };
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
			try
			{
				string fname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Last Name\t: ");
			try
			{
				string lname = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Date of Birth\t: ");
			try
			{
				string dob = Console.ReadLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Invalid value entered !");
			}
			Console.WriteLine("Address\t:");
			try
			{
				string address = Console.ReadLine();
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
			try
			{
				string modules_indexes = Console.ReadLine();
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
			string[] options = { "Module 2", "Module 4" };
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();

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
			string[] options = { "User 1", "User 2", "User 3" };
			Menu menu = new Menu(prompt, options);
			int selectedIndex = menu.Run();

			/*
			
			access 'user' by 'selectedIndex'

			remove 'user' from 'users' array

			 */
			RunMainMenu();
		}
		// Main Menu
		private void DisplayAllUsers()
		{
			Console.Clear();

			/*
			
				string modules_str="";
				foreach(Module mod:modules){
					modules += mod.Name;
					modules += " "; 
				}
				
				foreach(User user : Users){
					Console.WriteLine($"{user.FirstName}\t{user.LastName}\t{user.DateOfBirth}\t{user.Address}\t{modules_str}")
				}

			 */

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
