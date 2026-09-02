using System;
using System.Linq;
using Tamagochi.Api;
using Tamagotchi;

Console.WriteLine("===================================================");
Console.WriteLine("            WELCOME TO THE POKÉMON WORLD!           ");
Console.WriteLine("===================================================");
Console.WriteLine();
Console.WriteLine("Congratulations! Today is a very special day: you have finally turned 11 years old!");
Console.WriteLine("According to the law of the Pokémon League, you are now officially old enough");
Console.WriteLine("to become a Pokémon Trainer and set off on your very own journey.");
Console.WriteLine();
Console.WriteLine("Your first major task is to choose your very first partner Pokémon.");
Console.WriteLine("A loyal companion will protect you, grow alongside you, and become");
Console.WriteLine("your best friend in this exciting adventure!");
Console.WriteLine();
Console.WriteLine("Are you ready? The journey of a lifetime is about to begin...");
Console.WriteLine("---------------------------------------------------");
Console.Write("Please enter the name of the Pokémon you want to adopt: ");

string nomeDigitado = Console.ReadLine() ?? "";

var service = new PokemonApiService();
var pokemon = await service.TakePokemon(nomeDigitado);
Mechanics mechanics = new Mechanics();

if (pokemon != null)
{
    Console.WriteLine($"\nCongratulations! {pokemon.Nome.ToUpper()} is now yours! ");
    Console.WriteLine();
    Console.WriteLine("Which name do you want to give to your new Pokémon?");
    mechanics.name = Console.ReadLine() ?? "";
    mechanics.specie = pokemon.Nome;
    mechanics.type = string.Join(", ", pokemon.Tipos.Select(t => t.Type.Name));

    Console.WriteLine("Ok, your Pokémon is ready to start the adventure! Here are its initial stats:");
    Console.WriteLine();
    mechanics.ShowStatus();

    bool running = true;

    while (running && mechanics.vitality > 0)
    {
        mechanics.TimeUpdate();

        if (mechanics.vitality <= 0)
        {
            Console.WriteLine($"\n{mechanics.name} died! You have lost the game.");
            break;
        }

        Console.WriteLine();
        Console.WriteLine("\nWhat would you like to do with your Pokémon?");
        Console.WriteLine();
        Console.WriteLine("Type 'feed', 'play', 'sleep', 'cure', 'status', or 'exit'.\n");

        if (mechanics.tuberculosis)
        {
            Console.WriteLine("Warning: Your Pokémon has tuberculosis! Its vitality is decreasing faster than normal.");
        }

        if (mechanics.vitality < 25)
        {
            Console.WriteLine("Warning: Your Pokémon's vitality is low! Take care of it to prevent it from dying.");
        }

        if (mechanics.hungry >= 80)
        {
            Console.WriteLine("Warning: Your Pokémon is very hungry! Feed it to prevent its vitality from decreasing.");
        }

        if (mechanics.sleepness >= 80)
        {
            Console.WriteLine("Warning: Your Pokémon is very tired! Let it rest to prevent its vitality from decreasing.");
        }

        if (mechanics.energy <= 10)
        {
            Console.WriteLine("Warning: Your Pokémon is very low on energy! Let it rest to prevent its vitality from decreasing.");
        }

        if (mechanics.happiness <= 10)
        {
            Console.WriteLine("Warning: Your Pokémon is very unhappy! Play with it to prevent its vitality from decreasing.");
        }

        mechanics.comand = (Console.ReadLine() ?? "").ToLower();

        switch (mechanics.comand)
        {
            case "feed":
                mechanics.Feed();
                break;
            case "play":
                mechanics.Play();
                break;
            case "sleep":
                mechanics.Sleep();
                break;
            case "cure":
                mechanics.Cure();
                break;
            case "status":
                mechanics.ShowStatus();
                break;
            case "exit":
                mechanics.exit();
                running = false;
                break;
            default:
                Console.WriteLine("\nInvalid command!");
                break;
        }



        if (mechanics.vitality <= 0)
        {
            Console.WriteLine($"\n{mechanics.name} died! You have lost the game.");
            break;
        }
    }




}
else
{
    Console.WriteLine("\nPokémon not found! Make sure you typed the name correctly.");
}
