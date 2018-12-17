using System;

namespace EasyConsoleCore
{
    public static class Input
    {

        public static bool ReadBool(string prompt)
        {
            return ReadEnum<TrueFalse>(prompt) == TrueFalse.True;
        }



        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }
        public static int ReadInt(int min, int max)
        {
            int value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }
        public static int ReadInt()
        {
            string input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static double ReadDouble(string prompt, double min, double max)
        {
            Output.DisplayPrompt(prompt);
            return ReadDouble(min, max);
        }
        public static double ReadDouble(double min, double max)
        {
            double value = ReadDouble();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter a double value between {0} and {1} (inclusive)", min, max);
                value = ReadDouble();
            }

            return value;
        }
        public static double ReadDouble()
        {
            string input = Console.ReadLine();
            double value;

            while (!double.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter a double value");
                input = Console.ReadLine();
            }

            return value;
        }

        public static long ReadLong(string prompt, long min, long max)
        {
            Output.DisplayPrompt(prompt);
            return ReadLong(min, max);
        }
        public static long ReadLong(long min, long max)
        {
            long value = ReadLong();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadLong();
            }

            return value;
        }
        public static long ReadLong()
        {
            string input = Console.ReadLine();
            long value;

            while (!long.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }


        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            Type type = typeof(TEnum);

            if (!type.IsEnum)
                throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            Menu menu = new Menu();

            TEnum choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}
