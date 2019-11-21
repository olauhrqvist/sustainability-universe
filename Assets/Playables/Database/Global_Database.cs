using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global_Database : MonoBehaviour
{

    public List<TileClass> TileList = new List<TileClass>();

    //-----------Carnivore List-----------\\
    public List<WolfInfo> WolfList = new List<WolfInfo>();
    public List<shrewInfo> ShrewList = new List<shrewInfo>();
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
 
    // which list you want to add the Object, wolflist for wolf etc
  /*  public void AddWolfToDataBase(List<WolfInfo> lista, GameObject NewObject, string Name)
    {    
       // lista.Add(WolfInfo.Adding(Name,NewObject));
    }*/




//-----------Carnivore-----------\\

public class WolfInfo : Wolf  //varg
{
    public string TilePosition;
    public GameObject Newobject; 
    WolfInfo other;

    public WolfInfo WolfAdding(string tilename, GameObject NewObject)
    {
      other.TilePosition = tilename;
      other.Newobject = NewObject;

      return other;
    }
}


public class shrewInfo : Shrew //Näbbmus
    {
        public string TilePosition;
        public GameObject Newobject;
        shrewInfo other;

        public shrewInfo shrewAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }
   
        
public class WeaselInfo : Weasel //vessla
    {
        public string TilePosition;
        public GameObject Newobject;
        WeaselInfo other;

        public WeaselInfo WeaselAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }

    public class FoxInfo : Fox   //Fox
    {
        public string TilePosition;
        public GameObject Newobject;
        FoxInfo other;

        public FoxInfo FoxAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }

    //-----------Herbivore-----------\\

    public class MouseInfo : Mouse //möss
{
    public string TilePosition;

    public MouseInfo Adding(string tilename, MouseInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}


public class HareInfo : Hare //Hare
    {
        public string TilePosition;
        public GameObject Newobject;
        HareInfo other;

        public HareInfo HareAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }


    public class DeerInfo : RoeDeer //Rådjur
    {
        public string TilePosition;
        public GameObject Newobject;
        DeerInfo other;

        public DeerInfo DeerAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }


    public class MooseInfo : Moose   //älg
    {
        public string TilePosition;
        public GameObject Newobject;
        MooseInfo other;

        public MooseInfo MooseAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }

    //-----------Herbivore-----------\\

    public class SquirrelInfo : Squirrel  // Ekorre
    {
        public string TilePosition;
        public GameObject Newobject;
        SquirrelInfo other;

        public SquirrelInfo SquirrelAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }


    public class RatInfo : Rat            // råttor
    {
        public string TilePosition;
        public GameObject Newobject;
        RatInfo other;

        public RatInfo RatAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }


    public class WildBoarInfo : Boar    // vildsvin
    {
        public string TilePosition;
        public GameObject Newobject;
        WildBoarInfo other;

        public WildBoarInfo BoarAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }


    public class BrownBearInfo : BrownBear    // Björn
    {
        public string TilePosition;
        public GameObject Newobject;
        BrownBearInfo other;

        public BrownBearInfo BearAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }

    //-----------Tree-type-----------\\

    public class BeechInfo : Beech
    {
        public string TilePosition;
        public GameObject Newobject;
        BeechInfo other;

        public BeechInfo BeechAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }

    public class BirchInfo : Birch
    {
        public string TilePosition;
        public GameObject Newobject;
        BirchInfo other;

        public BirchInfo BirchAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }


    public class SpruceInfo : Spruce
    {
        public string TilePosition;
        public GameObject Newobject;
        SpruceInfo other;

        public SpruceInfo SpruceAdding(string tilename, GameObject NewObject)
        {
            other.TilePosition = tilename;
            other.Newobject = NewObject;

            return other;
        }
    }










}
