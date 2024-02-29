using GXPEngine;
using System;
using System.Drawing.Text;
using TiledMapParser;

internal class EnemySpawner : GameObject
{

    private int lives;
    private int spawnCap;
    private int spawninterval;
    private int spawnAmount;
    private float timer;


    public EnemySpawner(TiledObject obj = null) : base()
    {
        lives = obj.GetIntProperty("lives");
        spawnCap = obj.GetIntProperty("spawnCap");
        spawninterval = obj.GetIntProperty("spawnInterval"); // time (in miliseconds) between each spawn cycle
        spawnAmount = obj.GetIntProperty("spawnAmount"); 
    }




    private void spawnEnemy() 
    {
        MyGame myGame = (MyGame)game;
        Level level = myGame.GetLevel();
        Enemy enemy = new Enemy();
        level.AddChild(enemy);
    

    }

    void update() 
    {
        timer += Time.deltaTime;
        if (timer >= spawninterval) 
        {
            timer = 0;

            for (int i = 0; i < spawnAmount; i++) 
            {
                spawnEnemy();
            }
            


        }

        if (lives <= 0) 
        { 
            Destroy();
            Console.WriteLine("destroy spawner");
        }
    


    }


}

