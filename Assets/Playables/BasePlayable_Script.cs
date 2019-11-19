using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileTypes { podzol, dirt }

public abstract class Base_Playable : MonoBehaviour
{
    int ID;
    GameObject Mesh;
    public string Type;
    int Range;
    double OverallHealth = 100;
    int SpaceCost;
    Dictionary<string, double> Enviroments = new Dictionary<string, double>();
    int ForestID;
    int GrowthTime;
    string Species; // species

    protected Base_Playable(
                            string type,
                            int ID,
                            GameObject mesh,
                            int range,
                            int space,
                            Dictionary<string, double> enviroment,
                            int forestid,
                            int growthtime,
                            string species)
        {
            this.ID = ID;
            Mesh = mesh;
            Type = species;
            Range = range;
            SpaceCost = space;
            Enviroments = enviroment;
            ForestID = forestid;
            GrowthTime = growthtime;
        }
    public Dictionary<string, double> GetEnviroments() { return Enviroments; }
    public void SetModel(GameObject mesh) { Mesh = mesh; }
    public GameObject GetModel() { return Mesh; }
    public string GetSpecies() { return Species; }
    public string GetBaseType() { return Type; }
    public void SetID(int Input) { ID = Input; }
    public int GetID() { return ID; }
    public void SetRange(int Input) { Range = Input; }
    public int GetRange() { return Range; }
    public void SetOverallHealth(double Input) { OverallHealth = Input; }
    public double GetOverallHealth() { return OverallHealth; }
    public void SetSpaceCost(int Input) { SpaceCost = Input; }
    public int GetSpaceCost() { return SpaceCost; }
    public void SetForestID(int Input) { ForestID = Input; }
    public int GetForestID() { return ForestID; }
    public void SetGrowthTime(int Input) { GrowthTime = Input; }
    public int GetGrowthTime() { return GrowthTime; }

}
