namespace MultiDict;

public class ChineseEntry : Entry
{
    public string Hanzi { get; set; }
    public string Pinyin { get; set; }
    public string Translation { get; set; }
}


//dicts.Where(e => e.Pinyin == search)