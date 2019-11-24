using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPaster
{
	class Program
	{
		/// <summary>
		/// エントリポイント
		/// </summary>
		/// <param name="args"></param>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				string currentDir;
				if (args.Count() == 0)
				{
					currentDir = System.IO.Directory.GetCurrentDirectory();
				}
				else
				{
					if (System.IO.Directory.Exists(args[0]))
					{
						currentDir = args[0];
					}
					else
					{
						currentDir = System.IO.Directory.GetCurrentDirectory();
					}
				}

				string filePath = currentDir;
				filePath = System.IO.Path.Combine(filePath, DateTime.Now.ToString("s").Replace("-", "").Replace(":", "").Replace("T", ""));

				SmartPaster.Models.SmartPaster.Paster sp = new SmartPaster.Models.SmartPaster.Paster();

				filePath = System.IO.Path.ChangeExtension(filePath, sp.GetExt());

				using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
				{
					sp.ExportFile(fs);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}


		}
	}
}
