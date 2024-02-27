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
    private Menu menu;
    private float player1Health;
    private float player2health;
    private string[] levels = new string[2]; //array for levels (if you add more levels, you will have to increase the number)
    private int currentLevel = 0; // levels always start from 0
    
    public MyGame() : base(1920, 1080, false)
    {
        
        levels[0] = "Assets/Menu.tmx";
        levels[1] = "Assets/Test.tmx";
        LoadLevel(levels[0]);
    }

    void Update()
    {
        LoadInfo();
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
        if (Input.GetKeyUp(Key.ENTER)) // instead of changing the level in menu class it changes in here (menu class will be used for the button)
        {
            if (currentLevel == 0)
            {
                currentLevel = 1;
                LoadLevel(levels[currentLevel]); // deletes current level and loads the new given level
            }
        }
    }

    void LoadInfo()
    {
        if (player1 != null)
        {
            player1.health = player1Health;
        }
    }


    void LoadLevel(string name)
    {
        List<GameObject> children = GetChildren();

        foreach (GameObject child in children)
        {
            child.Destroy();
        }

        Level level = new Level(name);
        LateAddChild(level);
        if (currentLevel >= 1)
        {
            ui = new UI(width, height);
            LateAddChild(ui);
        }


    }


    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}