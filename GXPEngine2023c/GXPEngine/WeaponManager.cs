internal class WeaponManager
{
    public enum Weapons
    {
        WMPistol,
        WMAssaultRifle,
        WMShotgun
    }
    private Weapons currentWeapon;
    private Weapons newWeapon;

    public Weapons CurrentWeapon { get { return currentWeapon; } }
    public Weapons NewWeapon { get { return newWeapon; } }

    public WeaponManager()
    {

    }

    private void SwitchWeapon(Weapons weapon)
    {
        switch (weapon)
        {
            case Weapons.WMPistol:
                newWeapon = Weapons.WMAssaultRifle;
                break;
            case Weapons.WMAssaultRifle:
                newWeapon = Weapons.WMShotgun;
                break;
            case Weapons.WMShotgun:
                newWeapon = Weapons.WMPistol;
                break;

        }

    }

    public void DoSwitchWeapon()
    {
        SwitchWeapon(currentWeapon);
        currentWeapon = newWeapon;
    }




}

