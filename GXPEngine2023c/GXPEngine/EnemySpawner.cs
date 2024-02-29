using GXPEngine;
using System;
using System.Drawing.Text;
using TiledMapParser;

internal class EnemySpawner : Sprite
{

    private int lives;
    private int spawnCap;
    private int spawninterval;
    private int spawnAmount;
    private float timer;
    private Level level;

    public EnemySpawner(TiledObject obj = null) : base("Assets/EnemySpawner.png", false)
    {
        
        lives = obj.GetIntProperty("lives");
        spawnCap = obj.GetIntProperty("spawnCap");
        spawninterval = obj.GetIntProperty("spawnInterval"); // time (in miliseconds) between each spawn cycle
        spawnAmount = obj.GetIntProperty("spawnAmount");

        MyGame myGame = (MyGame)game;
        level = myGame.GetLevel();
    }




    private void spawnEnemy() 
    {
        Enemy enemy = new Enemy();
        enemy.x = x; enemy.y = y;
        parent.AddChild(enemy);
        Console.WriteLine(enemy.parent);
    }

    void Update() 
    {
        timer += Time.deltaTime;
        if (timer >= spawninterval) 
        {
            timer = 0;

            for (int i = 0; i < spawnAmount; i++) 
            {
                spawnEnemy();
            }
            lives--;


        }

        if (lives <= 0) 
        { 
            Destroy();
        }
    


    }


}

