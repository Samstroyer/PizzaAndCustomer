//This is "Papa's Pizzeria" - cheap version!

//I MEANT BASH A MONSTER!!! 

using Raylib_cs;

Setup();

Menu menu = new Menu();

Main();

void Setup()
{
    Raylib.InitWindow(600, 600, "Papa's Pizzeria");
}

void Main()
{
    while (!Raylib.WindowShouldClose())
    {
        menu.Run();
    }
}