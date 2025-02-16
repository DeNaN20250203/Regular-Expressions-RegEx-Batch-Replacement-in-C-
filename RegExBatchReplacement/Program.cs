using System.Text.RegularExpressions;

namespace RegExBatchReplacement
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Исходный текст, который будет обрабатываться регулярными выражениями
			string Text = "1 Onee, 2 Two, 33 Throoee is good.";

			// Список пар (шаблон, замена), где pattern — это регулярное выражение,
			// а output — строка, которой нужно заменить найденные совпадения.
			// данный набор замен может изменятьсяя по вашему желанию :)
			IList<(string pattern, string output)> patterns = [
				(@"\d+", "Цифра"), // Шаблон для поиска цифр и их замены на "Цифра"
    				("ee", "ёBbb-т"),  // Замена последовательности "ee" на "ёBbb-т"
    				("oo", "OOO-T")    // Замена последовательности "oo" на "OOO-T"
			];

			// Проверяем, есть ли хотя бы один шаблон в списке
			if (patterns.Count > 0)
			{
				// Проходим по каждому шаблону в списке
				for (int i = 0; i < patterns.Count; i++)
				{
					// Создаем объект Regex с текущим шаблоном, 
					// используя флаги Compiled и IgnoreCase
					// - Compiled: предварительная компиляция шаблона 
					// для улучшения производительности
					// - IgnoreCase: игнорирование регистра при поиске совпадений
					var rx = new Regex (patterns [i].pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

					// Выполняем замену всех совпадений в тексте на указанную замену
					Text = rx.Replace (Text, patterns [i].output);
				}

				// Выводим результат после всех замен
				Console.WriteLine ("Результат:\r\n" + Text);
			}
			else
			{
				// Если список шаблонов пустой, выводим сообщение об ошибке
				Console.WriteLine ("Ошибка:\r\nКоличество pattern и замен не совпадает!");
			}

			Console.ReadKey();
		}
	}
}
