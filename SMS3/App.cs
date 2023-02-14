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
		private void AddUser()
		{
			Console.Clear();
			Console.WriteLine("<< Add User >>");
			Console.WriteLine("First Name\t: ");
			try
			{
				string fname = Console.ReadLine();
			}
			catch(Exception ex)
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
			
			Do something with -> fname,lname,dob,address

			 */

			Console.WriteLine("\npress any key to exit...");
			Console.ReadKey(true);
			RunMainMenu();
		}
		private void SelectUser()
		{

		}
		private void DeleteUser()
		{

		}
		private void DisplayAllUsers()
		{

		}
		private void Quit()
		{

		}
	}
}
