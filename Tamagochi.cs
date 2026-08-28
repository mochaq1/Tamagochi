namespace Tamagotchi;

public class Mechanics
{
    public string name { get;  set; } = "";
    public string specie { get;  set; } = "";
    public string type { get;set; } = "";
    public int hungry { get;  set; } = 0;
    public int happiness { get;  set; } = 100;
    public int energy { get; set; } = 100;

    public Mechanics()
    {
    }

    public void ShowStatus()
    {

        Console.WriteLine("___________________________________________________________________________");
        Console.WriteLine("                            POKÉMON STATUS                                   ");
        Console.WriteLine();
        Console.WriteLine($"Name: {name}");
        Console.WriteLine();
        Console.WriteLine($"Specie: {specie}");
        Console.WriteLine();
        Console.WriteLine($"Type: {type}");
        Console.WriteLine();
        Console.WriteLine($"Hungry: {hungry}");
        Console.WriteLine();
        Console.WriteLine($"Happiness: {happiness}");
        Console.WriteLine();
        Console.WriteLine($"Energy: {energy}");
        Console.WriteLine("___________________________________________________________________________");
    }


}
