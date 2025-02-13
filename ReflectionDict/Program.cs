using System.Reflection;

namespace MultiDict;

public class Program
{
    public static void Demo_2()
    {
        Type typeProgram = typeof(Program);
        MethodInfo[] methodInfos = typeProgram.GetMethods();
        foreach (MethodInfo mInfo in methodInfos)
        {
            CustomAttributeData[] customAttr = mInfo.CustomAttributes.ToArray();

            Attribute attrib = mInfo.GetCustomAttribute(typeof(TestAttribute));
            if (attrib != null)
            {
                Console.WriteLine($"{mInfo.Name} {attrib}");
                mInfo.Invoke(new Program(), null);
            }
        }
    }

    public static void Main()
    {
        List<Entry> entries = new List<Entry>();
        entries.Add(new ChineseEntry()
        {
            Hanzi = "你好",
            Pinyin = "ni hao",
            Translation = "bonjour",
        });
        entries.Add(new ChineseEntry()
        {
            Hanzi = "拜拜",
            Pinyin = "bai bai",
            Translation = "au revoir",
        });
        entries.Add(new JapaneseEntry()
        {
            Kanji = "今日は",
            Kana = "konnichiwa",
            Traduction = "bonjour",
        });

        Type[] types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (Type type in types)
        {
            Console.WriteLine(type.CustomAttributes);

            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo p in props)
            {
                Console.WriteLine($"\t{p.Name}");
            }
        }

        Console.WriteLine("Type d'entrée ?");
        string line = Console.ReadLine();
        var result = GetEntries(entries, line);
        Console.WriteLine(result.Count());

        DisplayInfo(result[0]);
    }

    [Test]
    public void Demo()
    {
        Console.WriteLine("super demo !!");
    }

    static Entry[] GetEntries(IEnumerable<Entry> dictionary, string type)
    {
        type = type + "Entry";
        return dictionary
            .Where(e => e.GetType().Name == type)
            .ToArray();
    }

    static void DisplayInfo(Entry entry)
    {
        Type type = entry.GetType();
        Console.WriteLine(type.Name);
        PropertyInfo[] props = type.GetProperties();

        foreach (PropertyInfo p in props)
        {
            Console.Write($"\t{p.Name}: ");
            Console.WriteLine(p.GetValue(entry));
        }
    }
}
