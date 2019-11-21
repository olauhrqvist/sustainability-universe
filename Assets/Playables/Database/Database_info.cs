using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------Carnivore-----------\\

public class WolfInfo : Wolf  //varg
{   
    public string TilePosition;
    

    public WolfInfo Adding(string tilename, WolfInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class shrewInfo : Shrew //Näbbmus
{
    public string TilePosition;


    public shrewInfo Adding(string tilename, shrewInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class WeaselInfo : Weasel //vessla
{
    public string TilePosition;

    public WeaselInfo Adding(string tilename, WeaselInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class FoxInfo : Fox   //Fox
{
    public string TilePosition;

    public FoxInfo Adding(string tilename, FoxInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
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

    public HareInfo Adding(string tilename, HareInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class DeerInfo : RoeDeer //Rådjur
{
    public string TilePosition;

    public DeerInfo Adding(string tilename, DeerInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class MooseInfo : Moose   //älg
{
    public string TilePosition;

    public MooseInfo Adding(string tilename, MooseInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}

//-----------Herbivore-----------\\

public class SquirrelInfo : Squirrel  // Ekorre
{
    public string TilePosition;

    public SquirrelInfo Adding(string tilename, SquirrelInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class RatInfo : Rat            // råttor
{
    public string TilePosition;

    public RatInfo Adding(string tilename, RatInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }

}
public class WildBoarInfo : Boar    // vildsvin
{
    public string TilePosition;

    public WildBoarInfo Adding(string tilename, WildBoarInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class BrownBearInfo : BrownBear    // Björn
{
    public string TilePosition;

    public BrownBearInfo Adding(string tilename, BrownBearInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}

//-----------Tree-type-----------\\

public class BeechInfo : Beech   
{
    public string TilePosition;

    public BeechInfo Adding(string tilename, BeechInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class BirchInfo : Birch   
{
    public string TilePosition;

    public BirchInfo Adding(string tilename, BirchInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}
public class SpruceInfo : Spruce 
{
    public string TilePosition;

    public SpruceInfo Adding(string tilename, SpruceInfo NewObject)
    {
        NewObject.TilePosition = tilename;

        return NewObject;
    }
}

