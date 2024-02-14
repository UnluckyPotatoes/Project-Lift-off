using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    internal class EnemyHealthInfo : GameObject
    {
        Health enemyHealth = new Health(); 
        public EnemyHealthInfo():base() 
        {
            y = -10;
            HealthBar healthBar = new HealthBar();
            scale = 1/8f;
            healthBar.x = -80;
            enemyHealth.x = -78;
            AddChild(healthBar);
            AddChild(enemyHealth);
        }


        void Update()
        {
            if (parent != null)
            {
                float h = parent.health;
                float maxHealth = parent.maxHealth;
                enemyHealth.scaleX = (h / maxHealth);
            }
        }
    }

