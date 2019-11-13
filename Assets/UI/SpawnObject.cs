using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnObject : MonoBehaviour
{
    //public GameObject sampleObject;
    private TileClass tileclass;
    private SpawnMap spawnmap;
    private List<TileClass> tiles;

    public void AddObject(GameObject sampleObject)
    {

        transform.rotation = Quaternion.identity;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            GameObject TargetTile = hit.collider.gameObject;
            tiles = GameObject.Find("SpawnMap").GetComponent<SpawnMap>().tiles;
            TileClass tile = tiles.Find(x => x.name == TargetTile.name);
            tile.GrowObject(sampleObject);
        }
    }
}
