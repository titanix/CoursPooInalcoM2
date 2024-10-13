// See https://aka.ms/new-console-template for more information

int test = 0;
Console.WriteLine(test);
DemoInt(test);
// la valeur de la variable n'est pas modifiée
Console.WriteLine(test);


// Démonstration qu'un struct est bien un type valeur
Info info = new Info(5);
Console.WriteLine(info.Age);
DemoStruct(info);
Console.WriteLine(info.Age);
DemoStruct_2(info);
Console.WriteLine(info.Age);


Sandwich monDejeuner = Sandwich.JambonBeurre;
Console.WriteLine(monDejeuner);
Console.WriteLine((int)monDejeuner);


StackOverflow(0);


// Fonction utilisée pour montrer le comportement d'un type valeur
void DemoInt(int test)
{
    test = 3;
    Console.WriteLine(test);
}

void DemoStruct(Info a)
{
    a = new Info(10);
}

void DemoStruct_2(Info a)
{
    a.Age = 15;
}

int StackOverflow(int a)
{
    return 1 + StackOverflow(a);
}

// Déclaration d'une enum
enum Sandwich
{
    ThonMayo,
    JambonBeurre,
    PouletCurry,
}

struct Info
{
    public int Age = 5;

    public Info(int age)
    {
        Age = age;
    } 
}