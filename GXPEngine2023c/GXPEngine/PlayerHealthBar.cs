using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

    internal class PlayerHealthBar : GameObject
    {
        private Health playerHealth = new Health();
    public PlayerHealthBar() : base()
        {
            x = 0; y = 0;
            HealthBar healthBar = new HealthBar();
            HealthBackground healthBackground = new HealthBackground();
            AddChild(healthBar);
            AddChild(healthBackground);
            AddChild(playerHealth);
        }
        void Update()
        {
            if (game.FindObjectOfType<Player>() != null)
            {
                float playerMaxHealth = game.FindObjectOfType<Player>().maxHealth;
                float playerCurrentHealth = game.FindObjectOfType<Player>().health;
                playerHealth.scaleX = (playerCurrentHealth / playerMaxHealth);
            }
        }
    }
