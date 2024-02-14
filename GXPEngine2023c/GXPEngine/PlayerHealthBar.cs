using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    internal class PlayerHealthBar : GameObject
    {
        private Health playerHealth = new Health();
    public PlayerHealthBar() : base()
        {
            x = -240;
            y = -150;
            HealthBar healthBar = new HealthBar();
            HealthBackground healthBackground = new HealthBackground();
            AddChild(healthBar);
            AddChild(healthBackground);
            AddChild(playerHealth);
        }
        void Update()
        {
            
        }
    }
