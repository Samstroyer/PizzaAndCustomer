using Raylib_cs;

class Menu
{
    Game game;
    Customer menuCustomer;
    bool dispMenu = true;

    public Menu()
    {
        game = new();
        menuCustomer = new(400, 400);
    }

    public void Run()
    {
        if (dispMenu)
        {
            StartMenu();
            Keybinds();
        }
        else
        {
            Game();
        }
    }

    private void StartMenu()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.GRAY);

        menuCustomer.DrawCustomer();

        Raylib.DrawText("Press 's' to start\nPress 'e' to quit", 110, 90, 40, Color.ORANGE);

        Raylib.EndDrawing();
    }

    private void Game()
    {
        game.Run();
    }

    private void Keybinds()
    {
        KeyboardKey k = (KeyboardKey)Raylib.GetKeyPressed();

        if (k == KeyboardKey.KEY_E) { Raylib.CloseWindow(); }

        if (k == KeyboardKey.KEY_S) { dispMenu = false; }
    }


}