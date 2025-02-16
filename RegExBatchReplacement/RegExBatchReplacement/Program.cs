using System.Text.RegularExpressions;

namespace RegExBatchReplacement
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string Text = "1 Onee, 2 Two, 33 Throoee is good.";
			IList<string> pattern = [ @"\d+", "ee", "oo" ];
			IList<string> output = [ "Цифра", "ёBbb-т", "OOO-T" ];

			if (pattern.Count == output.Count)
			{
				for (int i = 0; i < output.Count; i++)
				{
					var rx = new Regex(pattern[i], RegexOptions.Compiled | RegexOptions.IgnoreCase);
					Text = rx.Replace(Text, output[i]);
				}
				Console.WriteLine("Результат:\r\n" + Text);
			}
			else
				Console.WriteLine("Ошибка:\r\nКоличество pattern и замен не совпадает!");

			Console.ReadKey();
		}
	}
}
