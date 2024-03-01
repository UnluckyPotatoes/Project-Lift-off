using System;

public class Shotgun : Weapon
{
    private int pellets = 5;
    private float spread;

    public int Pellets { get { return pellets; } }
    public Shotgun() : base(10, 7, 1f, 0.5f, "Assets/shotgun_inHand.png")
    {
        SetOrigin(width / 2, height / 2);
    }

    void Update()
    {
        if (parent != null)
        {
            for (int i = 0; i < pellets; i++)
            {
                Console.WriteLine("Shotgun");
                Updater(parent.x, parent.y);
            }




        }
    }

}

