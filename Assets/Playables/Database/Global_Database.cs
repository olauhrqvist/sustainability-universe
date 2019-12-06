using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Database : MonoBehaviour
{

    public List<TileClass> TileList = new List<TileClass>();

    public List<CarnivoreInfo> CarnivoreList = new List<CarnivoreInfo>();
    public List<HerbivoreInfo> HerbivoreList = new List<HerbivoreInfo>();
    public List<OmnivoreInfo> OmnivoreList = new List<OmnivoreInfo>();
    public List<TreeTypeInfo> TreeTypeList = new List<TreeTypeInfo>();


    public void AddCarnivore(string tile, string name, GameObject other)
    {
        CarnivoreList.Add(new CarnivoreInfo()
        {
            TilePosition = tile,
            name = name,
            Newobject = other

        });
        Debug.Log("toodels: " + name);
    }

    public void AddHerbivore(string tile, string name, GameObject other)
    {
        HerbivoreList.Add(new HerbivoreInfo()
        {
            TilePosition = tile,
            name = name,
            Newobject = other
        });
    }

    public void AddOmnivore(string tile, string name, GameObject other)
    {
        OmnivoreList.Add(new OmnivoreInfo()
        {
            TilePosition = tile,
            name = name,
            Newobject = other
        })
            ;
    }

    public void AddTreetype(string tile, string name, GameObject other)
    {
        TreeTypeList.Add(new TreeTypeInfo()
        {
            TilePosition = tile,
            name = name,
            Newobject = other
        });
        //print("add tree type, the tile is " + tile);
        //print("list count: " + TreeTypeList.Count);
    }

    public int calCarnivores(string tile)
    {
        int carnivores = 0;
        foreach (var c in CarnivoreList)
        {
            if (c.TilePosition == tile)
                carnivores++;
        }
        return carnivores;
    }

    public int calHerbivores(string tile)
    {
        int herbivores = 0;
        foreach (var c in HerbivoreList)
        {
            if (c.TilePosition == tile)
                herbivores++;
        }
        return herbivores;
    }

    public int calTreetype(string tile)
    {
        int treetype = 0;
        foreach (var c in TreeTypeList)
        {
            if (c.TilePosition == tile)
                treetype++;
        }

        return treetype;
    }

    public int calOmnivores(string tile)
    {
        int omnivores = 0;
        foreach (var c in OmnivoreList)
        {
            if (c.TilePosition == tile)
            {
                omnivores++;
            }
        }
        return omnivores;
    }


    //-----------Species List-----------\\
    //public List<GameObject> CarnivoreList = new List<GameObject>();

    // which list you want to add the Object, wolflist for wolf etc
    /*   public void AddWolfToDataBase(List<WolfInfo> lista, GameObject NewObject, string Name)
       {
          // lista.Add(WolfInfo.Adding(Name,NewObject));
       }

       public void addCarnivore(string name, GameObject other, string species)
       {
         CarnivoreList.Add(new CarnivoreInfo()
         {
           TilePosition = name,
           Newobject = other
         });
       }*/

    //-----------Carnivore List-----------\\
    public List<WolfInfo> WolfList = new List<WolfInfo>();
    public List<ShrewInfo> ShrewList = new List<ShrewInfo>();
    public List<WeaselInfo> WeaselList = new List<WeaselInfo>();
    public List<FoxInfo> FoxList = new List<FoxInfo>();

    //-----------Herbivore List-----------\\
    public List<MouseInfo> MouseList = new List<MouseInfo>();
    public List<HareInfo> HareList = new List<HareInfo>();
    public List<DeerInfo> DeerList = new List<DeerInfo>();
    public List<MooseInfo> MooseList = new List<MooseInfo>();

    //-----------Omnivore List-----------\\
    public List<SquirrelInfo> SquirrelList = new List<SquirrelInfo>();
    public List<RatInfo> RatList = new List<RatInfo>();
    public List<WildBoarInfo> BoarList = new List<WildBoarInfo>();
    public List<BrownBearInfo> BrownBearList = new List<BrownBearInfo>();

    //-----------TreeType List-----------\\
    public List<BeechInfo> BeechList = new List<BeechInfo>();
    public List<BirchInfo> BirchList = new List<BirchInfo>();
    public List<SpruceInfo> SpruceList = new List<SpruceInfo>();


//***********************************************



    public void AddWolf(string tile, GameObject other)
    {

      // Hierarchy 4
      WolfInfo wolf = new WolfInfo();
      wolf.TilePosition = tile;
      wolf.Newobject = other;
      WolfList.Add(wolf);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[wolf.GetFoodHierarchy()] += wolf.meatValue;
      tiles.Find(x => x.name == tile).foodHierarchy[wolf.GetFoodHierarchy() - 1] -= wolf.foodNeeded;
    }

    public void AddShrew(string tile, GameObject other)
    {

      ShrewInfo shrew = new ShrewInfo();
      shrew.TilePosition = tile;
      shrew.Newobject = other;
      ShrewList.Add(shrew);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[shrew.GetFoodHierarchy()] += shrew.meatValue;

        //tiles.Find(x => x.name == tile).foodHierarchy[shrew.GetFoodHierarchy() - 1] -= shrew.foodNeeded;
    }

    public void AddWeasel(string tile, GameObject other)
    {

      WeaselInfo weasel = new WeaselInfo();
      weasel.TilePosition = tile;
      weasel.Newobject = other;
      WeaselList.Add(weasel);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[weasel.GetFoodHierarchy()] += weasel.meatValue;
      tiles.Find(x => x.name == tile).foodHierarchy[weasel.GetFoodHierarchy() - 1] -= weasel.foodNeeded;

    }

    public void AddFox(string tile, GameObject other)
    {

      // Hierarchy 3
      FoxInfo fox = new FoxInfo();
      fox.TilePosition = tile;
      fox.Newobject = other;
      FoxList.Add(fox);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[fox.GetFoodHierarchy()] += fox.meatValue;
      tiles.Find(x => x.name == tile).foodHierarchy[fox.GetFoodHierarchy() - 1] -= fox.foodNeeded;

    }

    //-----------Herbivore-----------\\

    public void AddMouse(string tile, GameObject other)
    {

      // Hierarchy 1
      MouseInfo mouse = new MouseInfo();
      mouse.TilePosition = tile;
      mouse.Newobject = other;
      MouseList.Add(mouse);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[mouse.GetFoodHierarchy()] += mouse.meatValue;
      tiles.Find(x => x.name == tile).vegetationOnTile -= mouse.foodNeeded;


    }

    public void AddHare(string tile, GameObject other)
    {

      // Hierarchy 2
      HareInfo hare = new HareInfo();
      hare.TilePosition = tile;
      hare.Newobject = other;
      HareList.Add(hare);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[hare.GetFoodHierarchy()] += hare.meatValue;
      tiles.Find(x => x.name == tile).vegetationOnTile -= hare.foodNeeded;
    }

    public void AddDeer(string tile, GameObject other)
    {

      // Hierarchy 3
      DeerInfo deer = new DeerInfo();
      deer.TilePosition = tile;
      deer.Newobject = other;
      DeerList.Add(deer);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[deer.GetFoodHierarchy()] += deer.meatValue;
      tiles.Find(x => x.name == tile).vegetationOnTile -= deer.foodNeeded;

    }

    public void AddMoose(string tile, GameObject other)
    {

      // Hierarchy 4
      MooseInfo moose = new MooseInfo();
      moose.TilePosition = tile;
      moose.Newobject = other;
      MooseList.Add(moose);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[moose.GetFoodHierarchy()] += moose.meatValue;
      tiles.Find(x => x.name == tile).vegetationOnTile -= moose.foodNeeded;

    }

    //-----------Omnivore-----------\\

    public void AddSquirrel(string tile, GameObject other)
    {

      // Hierarchy 1
      SquirrelInfo squirrel = new SquirrelInfo();
      squirrel.TilePosition = tile;
      squirrel.Newobject = other;
      SquirrelList.Add(squirrel);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[squirrel.GetFoodHierarchy()] += squirrel.meatValue;
    }

    public void AddRat(string tile, GameObject other)
    {

      // Hierarchy 2
      RatInfo rat = new RatInfo();
      rat.TilePosition = tile;
      rat.Newobject = other;
      RatList.Add(rat);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[rat.GetFoodHierarchy()] += rat.meatValue;
      tiles.Find(x => x.name == tile).foodHierarchy[rat.GetFoodHierarchy() - 1] -= rat.foodNeeded;


    }

    public void AddBoar(string tile, GameObject other)
    {

      // Hierarchy 3
      WildBoarInfo boar = new WildBoarInfo();
      boar.TilePosition = tile;
      boar.Newobject = other;
      BoarList.Add(boar);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[boar.GetFoodHierarchy()] += boar.meatValue;
      tiles.Find(x => x.name == tile).foodHierarchy[boar.GetFoodHierarchy() - 1] -= boar.foodNeeded;


    }

    public void AddBear(string tile, GameObject other)
    {

      // Hierarchy 4
      BrownBearInfo bear = new BrownBearInfo();
      bear.TilePosition = tile;
      bear.Newobject = other;
      BrownBearList.Add(bear);
      List<TileClass> tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
      tiles.Find(x => x.name == tile).foodHierarchy[bear.GetFoodHierarchy()] += bear.meatValue;
      tiles.Find(x => x.name == tile).foodHierarchy[bear.GetFoodHierarchy() - 1] -= bear.foodNeeded;

    }

    //-----------Tree-type-----------\\

    public void AddBeech(string name, GameObject other)
    {
        BeechList.Add(new BeechInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddBirch(string name, GameObject other)
    {
        BirchList.Add(new BirchInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddSpruce(string name, GameObject other)
    {
        SpruceList.Add(new SpruceInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public int calculateWolf(string tile)
    {
        int number = 0;
        foreach (var w in WolfList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateShrew(string tile)
    {
        int number = 0;
        foreach (var w in ShrewList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateFox(string tile)
    {
        int number = 0;
        foreach (var w in FoxList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }

    public int calculateWeasel(string tile)
    {
        int number = 0;
        foreach (var w in WeaselList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }

    public int calculateSquirrel(string tile)
    {
        int number = 0;
        foreach (var w in SquirrelList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }

    public int calculateBoar(string tile)
    {
        int number = 0;
        foreach (var w in BoarList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }

    public int calculateRat(string tile)
    {
        int number = 0;
        foreach (var w in RatList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateBrownBear(string tile)
    {
        int number = 0;
        foreach (var w in BrownBearList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateMouse(string tile)
    {
        int number = 0;
        foreach (var w in MouseList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateHare(string tile)
    {
        int number = 0;
        foreach (var w in HareList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateMoose(string tile)
    {
        int number = 0;
        foreach (var w in MooseList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateDeer(string tile)
    {
        int number = 0;
        foreach (var w in DeerList)
        {
            if (w.TilePosition == tile)
                number++;
        }
        return number;
    }
    public int calculateCarnivores(string tile)
    {
        int carnivores = 0;
        foreach (var w in WolfList)
        {
            if (w.TilePosition == tile)
                carnivores++;
        }
        foreach (var s in ShrewList)
        {
            if (s.TilePosition == tile)
                carnivores++;
        }
        foreach (var f in FoxList)
        {
            if (f.TilePosition == tile)
                carnivores++;
        }
        foreach (var w in WeaselList)
        {
            if (w.TilePosition == tile)
                carnivores++;
        }
        return carnivores;
    }

    public int calculateTreetype(string tile)
    {
        int Tree = 0;

        foreach (var w in SpruceList)
        {
            if (w.TilePosition == tile)
                Tree++;
        }
        foreach (var w in BirchList)
        {
            if (w.TilePosition == tile)
                Tree++;

        }
        foreach (var w in BeechList)
        {
            if (w.TilePosition == tile)
                Tree++;
        }

        return Tree;
    }




    public int calculateOmnivores(string tile)
    {
        int omnivores = 0;
        foreach (var w in SquirrelList)
        {
            if (w.TilePosition == tile)
                omnivores++;
        }
        foreach (var s in BoarList)
        {
            if (s.TilePosition == tile)
                omnivores++;
        }
        foreach (var f in RatList)
        {
            if (f.TilePosition == tile)
                omnivores++;
        }
        foreach (var w in BrownBearList)
        {
            if (w.TilePosition == tile)
                omnivores++;
        }
        return omnivores;
    }

    public int calculateHerbivores(string tile)
    {
        int herbivores = 0;
        foreach (var w in MouseList)
        {
            if (w.TilePosition == tile)
                herbivores++;
        }
        foreach (var s in HareList)
        {
            if (s.TilePosition == tile)
                herbivores++;
        }
        foreach (var f in MooseList)
        {
            if (f.TilePosition == tile)
                herbivores++;
        }
        foreach (var w in DeerList)
        {
            if (w.TilePosition == tile)
                herbivores++;
        }
        return herbivores;
    }

}

/*public void calculateMeat(string tile)
{

}

public void calculateVeg(string tile)
{

}*/
