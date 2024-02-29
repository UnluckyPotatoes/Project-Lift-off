using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

public class Level : GameObject
{

    public Level(string f) : base()
    {
        Map leveldata = MapParser.ReadMap(f);
        TiledLoader loader = new TiledLoader(f);

        SpriteBatch batch = new SpriteBatch();
        AddChild(batch);
        loader.rootObject = batch;
        loader.addColliders = false;
        loader.LoadTileLayers(0); // background
        batch.Freeze();

        loader.rootObject = this;
        loader.addColliders = true;
        loader.LoadTileLayers(1); // Walls, Building, asset, etc.

        loader.addColliders = false;
        loader.LoadTileLayers(2); // decor

        loader.autoInstance = true;
        loader.LoadObjectGroups(); // Objects, Characters

        loader.LoadTileLayers(3); // foreGround
        
    }

}

