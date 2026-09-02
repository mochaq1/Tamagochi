namespace Tamagotchi;

public class Mechanics
{
    private int _hungry = 0;
    private int _happiness = 100;
    private int _energy = 100;
    private int _sleepness = 0;
    private int _vitality = 100;
    private int _level = 0;

    public string name { get; set; } = "";
    public string specie { get; set; } = "";
    public string type { get; set; } = "";
    public string comand { get; set; } = "";
    public int xp { get; set; } = 0;
    public DateTime lastUpdate = DateTime.Now;
    public bool tuberculosis = false;

    private Random random = new Random();

    public int hungry
    {
        get => _hungry;
        set => _hungry = Math.Clamp(value, 0, 100);
    }

    public int level
    {
        get => _level;
        set => _level = Math.Clamp(value, 1, 100);
    }

    public int happiness
    {
        get => _happiness;
        set => _happiness = Math.Clamp(value, 0, 100);
    }

    public int energy
    {
        get => _energy;
        set => _energy = Math.Clamp(value, 0, 100);
    }

    public int sleepness
    {
        get => _sleepness;
        set => _sleepness = Math.Clamp(value, 0, 100);
    }

    public int vitality
    {
        get => _vitality;
        set => _vitality = Math.Clamp(value, 0, 100);
    }

    public Mechanics()
    {
    }

    public void TimeUpdate()
    {
        DateTime now = DateTime.Now;
        double timeSinceLastUpdate = (now - lastUpdate).TotalSeconds;
        double cycle = timeSinceLastUpdate / 5.0;

        if (cycle >= 1.0)
        {
            int completeCycles = (int)Math.Floor(cycle);



            if (tuberculosis)
            {
                Console.WriteLine("Warning: Your Pokémon has tuberculosis! Its vitality is decreasing faster than normal.");
            }

            if (vitality < 25)
            {
                Console.WriteLine("Warning: Your Pokémon's vitality is low! Take care of it to prevent it from dying.");
            }

            if (hungry >= 80)
            {
                Console.WriteLine("Warning: Your Pokémon is very hungry! Feed it to prevent its vitality from decreasing.");
            }

            if (sleepness >= 80)
            {
                Console.WriteLine("Warning: Your Pokémon is very tired! Let it rest to prevent its vitality from decreasing.");
            }

            if (energy <= 10)
            {
                Console.WriteLine("Warning: Your Pokémon is very low on energy! Let it rest to prevent its vitality from decreasing.");
            }

            if (happiness <= 10)
            {
                Console.WriteLine("Warning: Your Pokémon is very unhappy! Play with it to prevent its vitality from decreasing.");
            }

            if (xp > level * 20)
            {

                levelUp();


            }






            if (!tuberculosis && random.Next(1, 101) <= 5)
            {
                tuberculosis = true;
                Console.WriteLine($"\n{name} has contracted tuberculosis! You need to take care of it!");
            }

            hungry += completeCycles * 2 - xp / 20;
            sleepness += completeCycles * 2 - xp / 20;
            energy -= completeCycles * 2 + xp / 20;
            happiness -= completeCycles * 1 + xp / 20;

            if (hungry >= 80)
            {
                vitality -= completeCycles * 3;
                energy -= completeCycles * 2;
            }

            if (sleepness >= 80)
            {
                vitality -= completeCycles * 3;
                happiness -= completeCycles * 2;
            }

            if (energy <= 10)
            {
                vitality -= completeCycles * 4;
                happiness -= completeCycles * 3;
            }

            if (happiness <= 10)
            {
                vitality -= completeCycles * 2;
                energy -= completeCycles * 1;
            }

            if (tuberculosis)
            {
                vitality -= completeCycles * 5;
                energy -= completeCycles * 3;
            }

            lastUpdate = lastUpdate.AddSeconds(completeCycles * 5);
        }
    }

    public void ShowStatus()
    {
        TimeUpdate();

        Console.WriteLine("__________________________________________________________________________");
        Console.WriteLine("                            POKÉMON STATUS                                   \n");

        Console.WriteLine($"Name: {name}\n");

        Console.WriteLine($"Specie: {specie}\n");

        Console.WriteLine($"Type: {type}\n");

        Console.WriteLine($"Hungry: {hungry}\n");
        Console.WriteLine($"Happiness: {happiness}\n");

        Console.WriteLine($"Energy: {energy}\n");

        Console.WriteLine($"Sleepness: {sleepness}\n");

        Console.WriteLine($"Vitality: {vitality}\n");

        Console.WriteLine($"Level: {level}\n");

        Console.WriteLine($"Tuberculosis: {(tuberculosis ? "Yes" : "No")}\n");

        Console.WriteLine("__________________________________________________________________________");
    }

    public void Feed()
    {
        TimeUpdate();
        hungry -= 10;
        happiness += 10;
        energy += 20;
        sleepness -= 10;
        xp += 5;

        Console.WriteLine($"\n{name} has been fed!");
        comand = "";
    }

    public void Play()
    {
        TimeUpdate();
        hungry += 10;
        happiness += 20;
        energy -= 20;
        sleepness += 10;
        xp += 10;

        Console.WriteLine($"\n{name} has played!");
        comand = "";
    }

    public void Sleep()
    {
        TimeUpdate();
        hungry += 20;
        happiness -= 10;
        energy += 30;
        sleepness -= 20;
        xp += 2;

        Console.WriteLine($"\n{name} has slept!");
        comand = "";
    }

    public void Cure()
    {
        TimeUpdate();
        if (tuberculosis)
        {
            tuberculosis = false;
            Console.WriteLine($"\n{name} has been cured of tuberculosis!");
        }
        else
        {
            Console.WriteLine($"\n{name} does not have tuberculosis.");
        }
        comand = "";
    }

    public void exit()
    {
        Console.WriteLine($"\nGoodbye! {name} will miss you!");
    }

    public void kill()
    {

        Console.WriteLine($"\nAre you stupid? You just killed your Pokémon! You're a monster! Poor {name}");
        vitality = 0;
    }

    public void levelUp()
    {
        level++;
        xp = 0;
        vitality = 100;
        hungry = 0;
        happiness = 100;
        energy = 100;
        sleepness = 0;

        Console.WriteLine($"\nCongratulations! {name} has leveled up to level {level}!");
    }
}
