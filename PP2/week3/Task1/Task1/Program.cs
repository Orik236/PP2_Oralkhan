using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
	enum FSIMode // Check File or Directory
	{
		DirectoryInfo = 1,
		File = 2
	}

	class Layer //Create Class
	{
		public int begin = 0;
		public int end = 10;
		public FileSystemInfo[] Content //Create array with "FileSystemInfo" type
		{
			get;
			set;
		}
		public int SelectedIndex //create constructor type int
		{
			get;
			set;
		}
		public void Show() //Show all files and directories in Selected directory
		{
			if (SelectedIndex < 0)
			{
				if (Content.Length < 10)
				{
					SelectedIndex = Content.Length - 1;
				}
				else
				{
					begin = Content.Length - 10;
					SelectedIndex = Content.Length - 1;
					end = Content.Length;
				}
			}
			if (SelectedIndex >= end)
			{
				begin++;
				end++;
			}
			if (SelectedIndex < begin)
			{
				begin--;
				end--;
			}
			if (SelectedIndex == Content.Length)
			{
				begin = 0;
				end = 10;
				SelectedIndex = 0;
			}
			Console.Clear();
			Console.WriteLine("Open: Enter || Rename: TAB || Delete: Del || Back: BackSpace || Close: ESC");
			Console.WriteLine();
			for (int i = begin; i < Math.Min(end, Content.Length); ++i) // show files from begin to end
			{
				if (i == SelectedIndex)
				{
					Console.BackgroundColor = ConsoleColor.Red;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Black;
				}
				if (Content[i].GetType() == typeof(DirectoryInfo))
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
				}
				else if(Content[i].GetType() == typeof(FileInfo))
				{
					Console.ForegroundColor = ConsoleColor.Blue;
				}
				Console.Write(i + 1 + ".  ");
				Console.WriteLine(Content[i].Name);
			}
			Console.BackgroundColor = ConsoleColor.Black;
		}
		public void Delete() //Delete our file or directory
		{
			Content[SelectedIndex].Delete();
			Console.Clear();
			Console.WriteLine("Файл успешно удален");
			Console.ReadKey();
			
		}
		public void Rename() //Rename our directory or file
		{
			string pr = new DirectoryInfo (Content[SelectedIndex].FullName).Parent.FullName;
			Console.ResetColor();
			Console.Clear();
			Console.Write("Please, Write new name: ");
			string name = Console.ReadLine();
			if (Content[SelectedIndex].GetType() == typeof(DirectoryInfo))
			{
				Directory.Move(Content[SelectedIndex].FullName, pr + '/' + name);
			}
			else
			{
				File.Move(Content[SelectedIndex].FullName, pr + '/' + name);
			}

		}

	}
	class Program
	{
		static void Main(string[] args)
		{
			DirectoryInfo dir = new DirectoryInfo(Console.ReadLine()); // read way to our directory
			Layer l = new Layer 
			{
				Content  = dir.GetFileSystemInfos(),
				SelectedIndex = 0
			};

			FSIMode curMode = FSIMode.DirectoryInfo; //Select directory mode

			Stack<Layer> history = new Stack<Layer>(); //Create stack where we push our directory
			history.Push(l);

			bool esc = false;
			while (!esc) // while true
			{
				if (curMode == FSIMode.DirectoryInfo)//if we in directory we will show all files and directory in selected directory
				{
					history.Peek().Show();
				}
				ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); 
				switch (consoleKeyInfo.Key)
				{
					case ConsoleKey.UpArrow: //select upper file or directory
						history.Peek().SelectedIndex--;
						break;
					case ConsoleKey.DownArrow://select lower file or directory
						history.Peek().SelectedIndex++;
						break;
					case ConsoleKey.Enter: //go in file or directory3
						int index = history.Peek().SelectedIndex;
						FileSystemInfo fsi = history.Peek().Content[index]; // creat new info in directory or file
						if (fsi.GetType() == typeof(DirectoryInfo)) //we push all file and directory in selected directory, then push in stack
						{
							curMode = FSIMode.DirectoryInfo;//select directory mode
							DirectoryInfo d = fsi as DirectoryInfo;
							history.Push(new Layer
							{
								Content = d.GetFileSystemInfos(),
								SelectedIndex = 0
							});
						}
						else //we write all text  in file
						{
							curMode = FSIMode.File;
							FileStream fs = new FileStream(fsi.FullName, FileMode.Open, FileAccess.Read); //Give way to our file, open mode file and read file
							StreamReader sr = new StreamReader(fs);
							
							Console.BackgroundColor = ConsoleColor.White;
							Console.ForegroundColor = ConsoleColor.Black;
							Console.Clear();
							Console.WriteLine(sr.ReadToEnd()); //write all texts in file
						}
						break;
					case ConsoleKey.Backspace: // back to previous directory or close file
						if (curMode == FSIMode.DirectoryInfo)
						{
							history.Pop();
						}
						else
						{
							curMode = FSIMode.DirectoryInfo;
							Console.ResetColor();
						}
						break;
					case ConsoleKey.Delete://Delete selecte file or Directory
						history.Peek().Delete();
						break;
					case ConsoleKey.Tab:
						history.Peek().Rename();
						break;
					case ConsoleKey.Escape:
						esc = true;
						break;
				}
			}
		}
	}
}