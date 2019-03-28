using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task1
{
	public class ComplexN
	{
		public double A
		{
			get;
			set;
		}
		public double B
		{
			get;
			set;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			F1();
			F2();
		}
		private static void F1()
		{
			ComplexN l = new ComplexN
			{
				A = 56,
				B = 5.4
			};
			FileStream fs = new FileStream("ComplexNumber.txt", FileMode.OpenOrCreate, FileAccess.Write);
			XmlSerializer xs = new XmlSerializer(typeof(ComplexN));
			xs.Serialize(fs, l);

			fs.Close();
		}
		private static void F2()
		{
			FileStream fs = new FileStream("ComplexNumber.txt", FileMode.Open, FileAccess.Read);
			XmlSerializer xs = new XmlSerializer(typeof(ComplexN));
			ComplexN t = xs.Deserialize(fs) as ComplexN;
			Console.WriteLine($"{t.A}  {t.B}");
			fs.Close();
		}
	}
}
