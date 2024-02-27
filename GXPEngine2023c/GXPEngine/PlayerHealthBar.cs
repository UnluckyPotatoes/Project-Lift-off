using GXPEngine;
using System;
using TiledMapParser;

internal class PlayerHealthBar : GameObject
{
    private Player player1;
    private Player player2;
    private Health player1Health = new Health();
    private Health player2Health = new Health();
    public PlayerHealthBar() : base()
    {
        scale = 2;
        HealthBar healthBar = new HealthBar();
        HealthBackground healthBackground = new HealthBackground();
        AddChild(healthBar);
        AddChild(healthBackground);
        AddChild(player1Health);
        FindPlayer();
    }

    void FindPlayer()
    {
        Player[] players = game.FindObjectsOfType<Player>();
        if (players.Length > 0)
        {
            foreach (Player player in players)
            {
                if (player.PlayerIndex == 1)
                {
                    player1 = player;
                }
                if (player.PlayerIndex == 2) 
                {
                    player2 = player;
                }
            }
        }

    }
    void Update()
    {
        if (player1 != null)
        {
            float player1CurrentHealth = player1.health;
            float player1MaxHealth = player1.maxHealth;
            
            player1Health.scaleX = (player1CurrentHealth / player1MaxHealth);
            
        }
        





    }
}
