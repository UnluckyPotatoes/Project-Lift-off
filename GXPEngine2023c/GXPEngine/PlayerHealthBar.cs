using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

    internal class PlayerHealthBar : GameObject
    {
        private Health player1Health = new Health();
        private Health player2Health = new Health();
    public PlayerHealthBar() : base()
        {
            x = 0; y = 0;
            HealthBar healthBar = new HealthBar();
            HealthBackground healthBackground = new HealthBackground();
            AddChild(healthBar);
            AddChild(healthBackground);
            AddChild(player1Health);
        }
        void Update()
        {
            if (game.FindObjectOfType<Player>() != null)
            {
                float player1MaxHealth = game.FindObjectOfType<Player>().maxHealth;
                float player1CurrentHealth = game.FindObjectOfType<Player>().health;
                player1Health.scaleX = (player1CurrentHealth / player1MaxHealth);
            }
        }
    }
