using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Database : MonoBehaviour
{

    //  public List<TileClass> TileList = new List<TileClass>();

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
        });
    }

    public void AddTreetype(string tile, string name, GameObject other)
    {
        TreeTypeList.Add(new TreeTypeInfo()
        {
            TilePosition = tile,
            name = name,
            Newobject = other
        });
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
        int carnivores = 0;
        foreach (var c in HerbivoreList)
        {
            if (c.TilePosition == tile)
                carnivores++;
        }
        return carnivores;
    }

    public int calTreetype(string tile)
    {
        int carnivores = 0;
        foreach (var c in TreeTypeList)
        {
            if (c.TilePosition == tile)
                carnivores++;
        }
        return carnivores;
    }

    public int calOmnivores(string tile)
    {
        int carnivores = 0;
        foreach (var c in TreeTypeList)
        {
            if (c.TilePosition == tile)
                carnivores++;
        }
        return carnivores;
    }

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
