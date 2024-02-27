using GXPEngine;

internal class EnemyHealthInfo : GameObject
{
    Health enemyHealth = new Health();
    public EnemyHealthInfo() : base()
    {
        y = -10;
        HealthBar healthBar = new HealthBar();
        scale = 1 / 8f;
        healthBar.x = -80;
        enemyHealth.x = -78;
        AddChild(healthBar);
        AddChild(enemyHealth);
    }


    void Update()
    {

        if (parent != null)
        {
            if (parent is Character) 
            { 
                Character character = (Character)parent;
                float h = character.health;
                float maxHealth = character.maxHealth;
                enemyHealth.scaleX = (h / maxHealth);
            }
           
            
            
        }
    }
}

