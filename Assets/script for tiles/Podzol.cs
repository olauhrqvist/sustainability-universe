using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Podzol : Tile
{
    //good for pine forrest
    //https://www.skogen.se/glossary/podsol
    private Podzol()
    {
        this.pH = 4.5;
        this.moisture = 70;
        this.nutrition = 40;

        
    }
    public override void setMoisture(int new_moisture )
    {
        this.moisture -= new_moisture;
    }

}
