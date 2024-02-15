using GXPEngine;                                // GXPEngine contains the engine
using GXPEngine.Core;
using System;                                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using TiledMapParser;
public class MyGame : Game
{
    private Player player1;
    private Player player2;
    private UI ui;
    private float player1Health;
    private float player2health;
    private string newLevel;
    
    public MyGame() : base(1920, 1080, false)
    {
        newLevel = "Test.tmx";
        
        OnAfterStep += LoadLevel;
    }

    void Update()
    {
        if (player1 != null)
        {
            player1Health = player1.health;
            player2health = player2.health;
        }
        if (Input.GetKey(Key.LEFT_SHIFT))
        {
            Console.WriteLine(currentFps);
            Console.WriteLine(GetDiagnostics());
        }
    }


    void DestroyLevel()
    {
        List<GameObject> children = GetChildren();
        for (int i = children.Count - 1; i >= 0; i--)
        {
            children[i].Destroy();
        }
    }


    public void MoveToLevel(string levelName)
    {
        newLevel = levelName;
    }

    void LoadLevel()
    {
        if (newLevel != null)
        {
            DestroyLevel();
            AddChild(new Level(newLevel));
            newLevel = null;
        }
    }



    void LoadInfo()
    {
        if (player1 != null)
        {
            player1.health = player1Health;
        }
    }


    

    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}