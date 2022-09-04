using System.Numerics;
using Raylib_cs;

class Game
{
    bool exit = false;
    Room currentRoom;

    List<Product> pizzas;

    List<Product> displayPizzas;

    private enum Room
    {
        Cashier,
        Kitchen
    }

    public Game()
    {
        currentRoom = Room.Cashier;
        pizzas = new();
        displayPizzas = new();
        displayPizzas.Add(new Product((450, 100), (true, true), 10));
    }

    public void Run()
    {
        while (!exit)
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.GRAY);

            Keybinds();

            switch (currentRoom)
            {
                case Room.Cashier:
                    Cashier();
                    foreach (Product p in displayPizzas)
                    {
                        p.Update();
                    }
                    break;


                case Room.Kitchen:
                    Kitchen();
                    foreach (Product p in pizzas)
                    {
                        p.Update();
                    }
                    break;


                default:

                    currentRoom = Room.Cashier;
                    break;
            }

            Orders();
            Overlay();

            Raylib.EndDrawing();
        }
    }

    public void Kitchen()
    {
        var mouseCords = Raylib.GetMousePosition();

        Raylib.DrawRectangle(090, 100, 080, 100, Color.LIGHTGRAY);
        Raylib.DrawRectangle(100, 110, 060, 080, Color.BLACK);
        Raylib.DrawText("Cheese", 102, 140, 16, Color.YELLOW);
        if (Raylib.CheckCollisionPointRec(mouseCords, new(100, 110, 060, 080)))
        {
            Raylib.DrawRectangle(100, 110, 060, 080, Colors.hoverColor);
            if (Raylib.IsMouseButtonPressed(0))
            {
                foreach (Product p in pizzas)
                {
                    if (Raylib.CheckCollisionCircleRec(new(p.x, p.y), 75, new(090, 100, 080, 100)))
                    {
                        p.cheese = !p.cheese;
                    }
                }
            }
        }

        Raylib.DrawRectangle(210, 100, 080, 100, Color.LIGHTGRAY);
        Raylib.DrawRectangle(220, 110, 060, 080, Color.BLACK);
        Raylib.DrawText("Tomato\nSauce", 222, 128, 16, Color.RED);
        if (Raylib.CheckCollisionPointRec(mouseCords, new(220, 110, 060, 080)))
        {
            Raylib.DrawRectangle(220, 110, 060, 080, Colors.hoverColor);
            if (Raylib.IsMouseButtonPressed(0))
            {
                foreach (Product p in pizzas)
                {
                    if (Raylib.CheckCollisionCircleRec(new(p.x, p.y), 75, new(220, 110, 060, 080)))
                    {
                        p.tomatoSauce = !p.tomatoSauce;
                    }
                }
            }
        }


        Raylib.DrawCircle(440, 140, 100, Colors.pepperoniZone);
        Raylib.DrawText("Pepperoni\nZone", 390, 110, 24, Color.RED);
    }

    public void Cashier()
    {
        Raylib.DrawRectangle(100, 400, 500, 050, Color.WHITE);
        Raylib.DrawRectangleLines(100, 400, 500, 050, Color.BLACK);
        Raylib.DrawRectangle(150, 450, 450, 150, Color.LIGHTGRAY);
        Raylib.DrawRectangleLines(150, 450, 450, 150, Color.BLACK);
    }

    public void Orders()
    {

    }

    public void Overlay()
    {
        var mouseCords = Raylib.GetMousePosition();

        Raylib.DrawRectangle(25, 525, 100, 50, Color.RED);
        Raylib.DrawText("Cashier", 27, 537, 26, Color.BLACK);
        if (Raylib.CheckCollisionPointRec(mouseCords, new(25, 525, 100, 50)))
        {
            Raylib.DrawRectangle(25, 525, 100, 50, Colors.hoverColor);
            if (Raylib.IsMouseButtonPressed(0))
            {
                currentRoom = Room.Cashier;
            }
        }

        Raylib.DrawRectangle(150, 525, 100, 50, Color.GREEN);
        Raylib.DrawText("Kitchen", 152, 537, 26, Color.BLACK);
        if (Raylib.CheckCollisionPointRec(mouseCords, new(150, 525, 100, 50)))
        {
            Raylib.DrawRectangle(150, 525, 100, 50, Colors.hoverColor);
            if (Raylib.IsMouseButtonPressed(0))
            {
                currentRoom = Room.Kitchen;
            }
        }

        System.Console.WriteLine(currentRoom);


        // Raylib.DrawRectangle(275, 525, 100, 50, Color.BLUE);
        // Raylib.DrawRectangle(400, 525, 100, 50, Color.YELLOW);
    }

    public void Keybinds()
    {
        KeyboardKey k = (KeyboardKey)Raylib.GetKeyPressed();

        if (k == KeyboardKey.KEY_K)
        {
            currentRoom = Room.Kitchen;
        }
        else if (k == KeyboardKey.KEY_C)
        {
            currentRoom = Room.Cashier;
        }

        if (k == KeyboardKey.KEY_N)
        {
            pizzas.Add(new Product());
        }

        if (k == KeyboardKey.KEY_ESCAPE)
        {
            exit = true;
        }

        if (k == KeyboardKey.KEY_T)
        {
            pizzas = new();
        }
    }
}