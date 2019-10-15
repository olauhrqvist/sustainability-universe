using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BrownEarth : Tile
{
    public BrownEarth()
    {
        this.pH = 6.5;
        this.moisture = 30;
    }
    public override void setMoisture(int new_moisture)
    {
        this.moisture -= new_moisture;
    }

}
