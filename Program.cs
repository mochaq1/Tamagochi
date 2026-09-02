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

while (true)
{
    string dName = Console.ReadLine() ?? "";

    var service = new PokemonApiService();
    var pokemon = await service.TakePokemon(dName);
    Mechanics mechanics = new Mechanics();

    if (pokemon != null)
    {
        Console.WriteLine($"\nCongratulations! {pokemon.Nome.ToUpper()} is now yours! ");


        Console.WriteLine("\nWhich name do you want to give to your new Pokémon?");
        mechanics.name = Console.ReadLine() ?? "";
        mechanics.specie = pokemon.Nome;
        mechanics.type = string.Join(", ", pokemon.Tipos.Select(t => t.Type.Name));

        Console.WriteLine("\nOk, your Pokémon is ready to start the adventure! Here are its initial stats:");
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
                case "kill":
                    mechanics.kill();
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
        Console.WriteLine($"\nSorry, the Pokémon '{dName}' was not found. Please try again.");

    }
}
