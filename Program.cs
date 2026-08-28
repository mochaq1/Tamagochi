using System;
using Tamagochi.Api;
using Tamagotchi;




    Console.WriteLine("===================================================");
    Console.WriteLine("           WELCOME TO THE POKÉMON WORLD!           ");
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
        Console.WriteLine("Wich name do you want to give to your new Pokémon?");
        mechanics.name = Console.ReadLine();
        mechanics.specie = pokemon.Nome;
        mechanics.type = string.Join(", ", pokemon.Tipos.Select(t => t.Type.Name));

        Console.WriteLine("Ok, your Pokémon is ready to start the adventure! Here are its initial stats:");
        Console.WriteLine();
        mechanics.ShowStatus();



    }
    else
    {
        Console.WriteLine("\nPokémon not found! Make sure you typed the name correctly.");

    }
