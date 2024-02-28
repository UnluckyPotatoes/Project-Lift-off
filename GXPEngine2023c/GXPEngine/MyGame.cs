using GXPEngine;                                // GXPEngine contains the engine
using GXPEngine.Core;
using System;                                   // System contains a lot of default C# libraries 
using System.Collections.Generic;
using TiledMapParser;
public class MyGame : Game
{
    private UI ui;
    public string[] levels = new string[5]; //array for levels (if you add more levels, you will have to increase the number)
    private int currentLevel = 0; // levels always start from 0

    public int GetCurrentLevel() //returns current level
    {
        return currentLevel;
    }
    public void SetCurrentLevel(int _value) //sets new level and deletes old level
    {
        currentLevel = _value;
        LoadLevel(levels[currentLevel]);
    }



    public MyGame() : base(1920, 1080, false)
    {

        levels[0] = "Assets/Menu.tmx";
        levels[1] = "Assets/Test.tmx";
        levels[2] = "Assets/SecondLevel.tmx";
        levels[3] = "Assets/ThirdLevel.tmx";
        levels[4] = "Assets/GameOver.tmx";
        LoadLevel(levels[0]);
    }

    void Update()
    {

        if (Input.GetKey(Key.LEFT_SHIFT))
        {
            Console.WriteLine(currentFps);
            Console.WriteLine(GetDiagnostics());
        }
        if (Input.GetKeyUp(Key.ENTER)) // instead of changing the level in menu class it changes in here (menu class will be used for the button)
        {
            if (currentLevel == 0)
            {
                SetCurrentLevel(1); // deletes current level and loads the new given level
            }
            if (currentLevel == 4)
            {
                SetCurrentLevel(1);
            }
        }
    }


    private void LoadLevel(string name) // level loader
    {
        List<GameObject> children = GetChildren();

        foreach (GameObject child in children)
        {
            child.Destroy();
        }
        Level levels = new Level(name);
        AddChild(levels);
        if (currentLevel >= 1)
        {
            ui = new UI(width, height);
            AddChild(ui);
        }


    }


    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}