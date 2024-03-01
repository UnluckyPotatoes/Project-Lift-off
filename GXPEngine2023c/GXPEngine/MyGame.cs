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
    private Sound levelSwitchSound = new Sound("Assets/Level_entry_and_exit_sound.wav");
    private Level Activelevel;

    public int GetCurrentLevel() //returns current level
    {
        return currentLevel;
    }
    public void SetCurrentLevel(int _value) //sets new level and deletes old level
    {
        currentLevel = _value;
        if (currentLevel >= 5) { currentLevel = 4; }
        LoadLevel(levels[currentLevel]);
    }


    public Level GetLevel() { return Activelevel; }


    public MyGame() : base(1920, 1080, false)
    {

        levels[0] = "Assets/Level_Menu.tmx";
        levels[1] = "Assets/Level_One.tmx";
        levels[2] = "Assets/Level_Two.tmx";
        levels[3] = "Assets/Level_Three.tmx";
        levels[4] = "Assets/Level_Game_Over.tmx";
        LoadLevel(levels[0]);
    }

    void Update()
    {
        EnemyChecker();

        if (Input.GetKey(Key.LEFT_SHIFT))
        {
            Console.WriteLine(currentFps);
            Console.WriteLine(GetDiagnostics());
        }

        if (Input.GetKeyUp(Key.ENTER)) // instead of changing the level in menu class it changes in here (menu class will be used for the button)
        {
            if (currentLevel == 0)
            {
                levelSwitchSound.Play();
                SetCurrentLevel(1); // deletes current level and loads the new given level
            }
            if (currentLevel == 4)
            {
                levelSwitchSound.Play();
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

        Activelevel = new Level(name);
        AddChild(Activelevel);
        
        if (currentLevel >= 1 && currentLevel != 4)
        {
            ui = new UI(width, height);
            AddChild(ui);
        }

        Sound steppingSound;

        switch (currentLevel)
        {
            case 2:
                steppingSound = new Sound("Assets/GrassfootstepLevel_1.wav");
                break;
            case 1: case 3:
                steppingSound = new Sound("Assets/Rock_Footsteps.wav");
                break;
            default:
                steppingSound = null;
                break;

        }

        if (steppingSound != null) { FindObjectOfType<Player>().ApplySound(steppingSound); }

        
    }

    private void EnemyChecker() 
    {
        GameObject[] enemyCount = FindObjectsOfType<Enemy>();
        GameObject[] enemySpawnerCount = FindObjectsOfType<EnemySpawner>();
        if (enemyCount.Length <= 0 && enemySpawnerCount.Length <= 0 && (currentLevel != 0)) 
        { 

            NextLevel();
            
        }

    }



    private void NextLevel() 
    {
        Console.WriteLine("next level");
        SetCurrentLevel(currentLevel += 1);
        
    }



    static void Main()                          // Main() is the first method that's called when the program is run
    {
        new MyGame().Start();                   // Create a "MyGame" and start it
    }
}