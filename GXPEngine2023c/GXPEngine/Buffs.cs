using GXPEngine;


internal class Buffs : Sprite
{
    public string buffType;

    public Buffs(string img, string type) : base(img, false, true)
    {
        collider.isTrigger = true;
        buffType = type;
    }


    





}

