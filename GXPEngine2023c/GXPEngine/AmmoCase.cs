public enum AmmoCaseType
{
    Pistol,
    AssaultRifle,
    Shotgun
}
internal class AmmoCase : Pickup
{
    private int AmmoType;

    public int GetAmmoType { get { return AmmoType; } }


    public AmmoCase(string img, int type) : base(img)
    {
        AmmoType = type;
    }

}

