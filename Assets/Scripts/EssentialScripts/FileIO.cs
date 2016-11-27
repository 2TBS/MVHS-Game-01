using UnityEngine;
using System.Collections;
using System.IO;

namespace FileIO 
{
	public class FileIO : MonoBehaviour {

		///Returns file contents as a string array.
		///default filePath = Assets/
		public string[] ReadFile(string filePath) 
		{
			using (var reader = new StreamWriter(filePath)) {
				return File.ReadAllLines(filePath);
			}
		}

		public string ReadLine(string filePath, int lineNo)
		{
			using (var reader = new StreamWriter(filePath)) {
				return File.ReadAllLines(filePath) [lineNo - 1];
			}
		}

		public void WriteToFile(string filepath, string nextLine)
		{

		}

		public void WriteToFile(string filepath, string[] nextlines)
		{
			using (var writer = new StreamWriter(filepath)) {
				File.WriteAllLines(filepath, nextlines);
			}
		}

		public void WriteToFile(string filepath, string[] nextlines, bool overwrite)
		{
			if(overwrite)
			{
				File.Delete(filepath);
				CreateFile(filepath, nextlines);
			}

			WriteToFile(filepath, nextlines);
		}

		public void CreateFile(string filepath)
		{
			File.Create(filepath);
		}

		public void CreateFile(string filepath, string[] initContent)
		{
			File.Create(filepath);
			
		}
	}
}
