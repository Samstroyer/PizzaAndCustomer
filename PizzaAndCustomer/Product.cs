using System.Numerics;
using Raylib_cs;

public static class Colors
{
    public static Raylib_cs.Color pizzaColor = new(219, 162, 74, 255);
    public static Raylib_cs.Color pizzaCrustColor = new(169, 112, 24, 255);

    public static Raylib_cs.Color pepperoniOuter = new(180, 14, 14, 255);
    public static Raylib_cs.Color pepperoniInner = new(221, 44, 44, 255);

    public static Raylib_cs.Color hoverColor = new(0, 120, 0, 75);
    public static Raylib_cs.Color clickColor = new(0, 120, 0, 255);

    public static Raylib_cs.Color pepperoniZone = new(0, 0, 0, 60);
}


class Product
{
    public int x, y;
    public List<(int x, int y)> pepperoni;
    public bool cheese, tomatoSauce, display;

    Random? r;

    public Product()
    {
        display = false;
        x = 100; y = 300;
        cheese = false; tomatoSauce = false;
        pepperoni = new();
    }

    public Product((int x, int y) pos, (bool cheese, bool tomatoSauce) bases, int amountOfPepperoni)
    {
        display = true;
        r = new();
        x = pos.x; y = pos.y;
        cheese = bases.cheese; tomatoSauce = bases.tomatoSauce;
        pepperoni = new();

        for (int i = 0; i < amountOfPepperoni; i++)
        {
            bool goodPlacement = false;
            int x_, y_;

            do
            {
                x_ = r.Next(-75, 75);
                y_ = r.Next(-75, 75);
                goodPlacement = Raylib.CheckCollisionPointCircle(new(x + x_, y + y_), new(x, y), 55);
            } while (!goodPlacement);

            pepperoni.Add((x_, y_));
        }
    }

    public void Update()
    {
        Draw();

        if (!display)
        {
            MovePizza();

            if (Raylib.CheckCollisionCircles(new(440, 140), 100, new(x, y), 70))
            {
                AddPepperoni();
            }
        }
    }

    private void Draw()
    {
        Raylib.DrawCircle(x, y, 75, Colors.pizzaCrustColor);
        Raylib.DrawCircle(x, y, 65, Colors.pizzaColor);

        if (tomatoSauce)
        {
            Raylib.DrawCircle(x, y, 63, Color.RED);
        }

        if (cheese)
        {
            Raylib.DrawTexture(Loads.cheese, x - 70, y - 70, Color.WHITE);
        }

        foreach (var p in pepperoni)
        {
            Raylib.DrawCircle(x + p.x, y + p.y, 10, Colors.pepperoniOuter);
            Raylib.DrawCircle(x + p.x, y + p.y, 8, Colors.pepperoniInner);
        }
    }

    private void CheeseToggle()
    {

    }

    private void TomatoSauceToggle()
    {

    }

    private void AddPepperoni()
    {
        var mouseCords = Raylib.GetMousePosition();

        if (Raylib.CheckCollisionPointCircle(new(mouseCords.X, mouseCords.Y), new(x, y), 65))
        {
            Raylib.DrawCircle((int)mouseCords.X, (int)mouseCords.Y, 10, Colors.pepperoniOuter);
            Raylib.DrawCircle((int)mouseCords.X, (int)mouseCords.Y, 8, Colors.pepperoniInner);

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT))
            {
                pepperoni.Add(new(((int)mouseCords.X - x), ((int)mouseCords.Y) - y));
            }
        }
    }

    private void MovePizza()
    {
        var mouseCords = Raylib.GetMousePosition();

        if (Raylib.CheckCollisionPointCircle(new(mouseCords.X, mouseCords.Y), new(x, y), 65))
        {
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                Raylib.DrawCircle(x, y, 75, Colors.clickColor);
                x += (int)Raylib.GetMouseDelta().X;
                y += (int)Raylib.GetMouseDelta().Y;
            }
            else
            {
                Raylib.DrawCircle(x, y, 75, Colors.hoverColor);
            }
        }
    }

}