### Menu

- Improves MVC approach to the project
- Gets rid of switch - case usage
- Numbers of options is not your buisness anymore!
- Flexible

### Before
```c#
public class Main
{
	public static void main(string[] args)
	{
		Logic logic = new Logic();
		bool exit = false;
		string input;
		while(!exit)
		{
			Console.Clear();
			Console.WriteLine("Possible options: ");
			Console.WriteLine("1. Sum");
			Console.WriteLine("2. Difference");
			Console.WriteLine("3. Multiply");
			Console.WriteLine("4. Divide");
			Console.WriteLine("5. Exit");
			input = Console.ReadLine();
			switch(input)
			{
				case "1": logic.Sum(); break;
				case "2": logic.Difference(); break;
				case "3": logic.Multiply(); break;
				case "4": logic.Divide(); break;
				case "5": exit = true; break;
				default:
					Console.WriteLine("There's no such option!");
					Console.ReadLine(); break;
			}
		}
	}
}
```
### After
```csharp
public class Main
{
	public static void main(string[] args)
	{
		Logic logic = new Logic();
		Menu("Possible options: ", new Dictionary<string, Action>
		{
			{ "Sum", new Action(logic.Sum) },
			{ "Difference", new Action(logic.Difference) },
			{ "Multiply", new Action(logic.Multiply) },
			{ "Divide", new Action(logic.Divide) }
		} "Exit" );
	}
}
```