using System.Collections;

string gameName = "New Adventures With Magic";
string selectedCharacter;
int characterId;
var enemy = new Dictionary<string, float>();
var hero = new Dictionary<string, float>();
var enemies = new ArrayList();
Random rand = new Random();

int damage = rand.Next(1, 51);

var characters = new Dictionary<string, Dictionary<string, float>>()
{
    { "Berserk", new Dictionary<string, float> { { "health", 80 }, { "armor", 80 }, { "damage", damage } } },
    { "Assassin", new Dictionary<string, float> { { "health", 60 }, { "armor", 60 }, { "damage", damage } } },
    { "Cleric", new Dictionary<string, float> { { "health", 90 }, { "armor", 90 }, { "damage", damage } } },
    { "Template", new Dictionary<string, float> { { "health", 100 }, { "armor", 100 }, { "damage", damage } } },
};

Console.WriteLine($"Welcome to my game by named: {gameName}");
Console.WriteLine("Characters:");

foreach (var character in characters)
{
    enemies.Add(character.Key);
    Console.WriteLine(character.Key);
    Console.WriteLine("------------------------------------");

    foreach (var characteristics in character.Value)
    {
        Console.WriteLine($"{characteristics.Key}:{characteristics.Value}");
    }

    Console.WriteLine("------------------------------------");
}

Console.Write("Write a character name to play for: ");
selectedCharacter = Console.ReadLine();

while (!characters.TryGetValue(selectedCharacter, out hero))
{
    Console.Write("That character doesn't exit. Try again: ");
    selectedCharacter = Console.ReadLine();
}

Console.Write("Your enemy: ");
characterId = rand.Next(0, enemies.Count);

if (characters.TryGetValue(Convert.ToString(enemies[characterId]), out enemy))
{
    Console.WriteLine(enemies[characterId]);
}

while (hero["health"] > 0 && enemy["health"] > 0)
{
    hero["health"] -= hero["damage"] / 100 * hero["armor"];
    enemy["health"] -= enemy["damage"] / 100 * enemy["armor"];
    Console.WriteLine($"hero health {hero["health"]}, enemy health is {enemy["health"]}");
}

if (hero["health"] <= 0 && enemy["health"] <= 0)
{
    Console.WriteLine("Draw");
}
else if (hero["health"] <= 0)
{
    Console.WriteLine($"Enemy is win. Health: {Convert.ToInt32(enemy["health"])}");
}
else
{
    Console.WriteLine($"Hero is win. Health: {Convert.ToInt32(hero["health"])}");
}