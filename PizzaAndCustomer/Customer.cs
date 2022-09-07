using System.Numerics;
using Raylib_cs;

class Customer
{
    Vector2 pos;
    (bool tomatoSauce, bool cheese, int slices) ingredientReq;
    Random? r;

    public Customer(int xCenter, int yCenter)
    {
        pos = new(xCenter, yCenter);
    }

    public Customer()
    {
        ingredientReq = new();
        r = new();
        pos = new(400, 300);

        if (r.NextDouble() < 0.5)
        {
            ingredientReq.tomatoSauce = true;
        }

        if (r.NextDouble() < 0.5)
        {
            ingredientReq.cheese = true;
        }

        ingredientReq.slices = r.Next(15);
    }

    public void DrawCustomer()
    {
        int x = (int)pos.X;
        int y = (int)pos.Y;
        //Head + Hair
        Raylib.DrawEllipse(x, y, 100, 150, Color.BEIGE);
        Raylib.DrawTexture(Loads.hair, x - 125, y - 200, Color.WHITE);

        //Eyes (left)
        Raylib.DrawEllipse(x - 50, y - 25, 20, 15, Color.BROWN);
        Raylib.DrawEllipse(x - 50, y - 20, 20, 15, Color.WHITE);
        Raylib.DrawEllipse(x - 50, y - 20, 2, 2, Color.BLACK);
        //Eyes (right)
        Raylib.DrawEllipse(x + 50, y - 25, 20, 15, Color.BROWN);
        Raylib.DrawEllipse(x + 50, y - 20, 20, 15, Color.WHITE);
        Raylib.DrawEllipse(x + 50, y - 20, 2, 2, Color.BLACK);

        //Mouth + Lips
        Raylib.DrawCircleSector(new Vector2(x, y + 48), 50, -90, 90, 1, Color.RED);
        Raylib.DrawCircleSector(new Vector2(x, y + 50), 45, -90, 90, 1, Color.BLACK);

        //Tounge + "texture"(...)
        Raylib.DrawRectangle(x - 6, y + 62, 12, 20, Color.RED);
        Raylib.DrawCircle(x, y + 82, 6, Color.RED);
        Raylib.DrawRectangle(x - 1, y + 64, 2, 16, Color.BLACK);
    }
}