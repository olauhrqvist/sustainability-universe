﻿using System.Collections;
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
        print("add tree type, the tile is " + tile);
        print("list count: " + TreeTypeList.Count);
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



    public void AddWolf(string name, GameObject other)
    {
        WolfList.Add(new WolfInfo()
        {
            TilePosition = name,
            Newobject = other
        });
    }

    public void AddShrew(string name, GameObject other)
    {
        ShrewList.Add(new ShrewInfo()
        {
            TilePosition = name,
            Newobject = other
        });
    }

    public void AddWeasel(string name, GameObject other)
    {
        WeaselList.Add(new WeaselInfo()
        {
            TilePosition = name,
            Newobject = other
        });
    }

    public void AddFox(string name, GameObject other)
    {
        FoxList.Add(new FoxInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    //-----------Herbivore-----------\\

    public void AddMouse(string name, GameObject other)
    {
        MouseList.Add(new MouseInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddHare(string name, GameObject other)
    {
        HareList.Add(new HareInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddDeer(string name, GameObject other)
    {
        DeerList.Add(new DeerInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddMoose(string name, GameObject other)
    {
        MooseList.Add(new MooseInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    //-----------Herbivore-----------\\

    public void AddSquirrel(string name, GameObject other)
    {
        SquirrelList.Add(new SquirrelInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddRat(string name, GameObject other)
    {
        RatList.Add(new RatInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddBoar(string name, GameObject other)
    {
        BoarList.Add(new WildBoarInfo()
        {
            TilePosition = name,
            Newobject = other
        });

    }

    public void AddBear(string name, GameObject other)
    {
        BrownBearList.Add(new BrownBearInfo()
        {
            TilePosition = name,
            Newobject = other
        });

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






