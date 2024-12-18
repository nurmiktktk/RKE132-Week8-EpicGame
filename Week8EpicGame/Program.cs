string folderPath = @"C:\Users\Default\Desktop\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";
string weaponFile = "weapon.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villians = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapons = File.ReadAllLines(Path.Combine(folderPath, weaponFile));

//string[] heroes = {"Harry Potter", "Luke Skywalker", "Lara Croft", "Bilbo Baggins", "Scooby-Doo"};
//string[] villians = {"Voldemort", "Darth Vader", "Dracula", "Joker", "Sauron"};
//string[] weapon = { "uzi", "glock-18", "lightsaber", "zombie knife", "meaty bone" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapons);
int heroHp = GetCharacterHP(hero);
int heroStrikeStrenght = heroHp;
Console.WriteLine($"Today {hero} ({heroHp} HP) with {heroWeapon} saves the day!");


string villain = GetRandomValueFromArray(villians);
string villainWeapon = GetRandomValueFromArray(weapons);
int villainHp = GetCharacterHP(villain);
int villainStrikeStrenght = villainHp;
Console.WriteLine($"Today {villain} ({villainHp} HP) with {villainWeapon} tries to take over the world!");

while (heroHp > 0 && villainHp > 0)
{
    heroHp = heroHp - Hit(villain, villainStrikeStrenght);
    villainHp = villainHp - Hit(hero, heroStrikeStrenght);
}

Console.WriteLine($"Hero {hero} HP: {heroHp}");
Console.WriteLine($"Villain {villain} HP: {villainHp}");

if (heroHp > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
if (villainHp > 0)
{
    Console.WriteLine("Dark side wins!");
}

else if (heroHp < 0 && villainHp < 0)
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random random = new Random();
    int strike = random.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }

    return strike;
}