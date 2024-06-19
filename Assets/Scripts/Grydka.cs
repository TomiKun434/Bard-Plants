using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Grydka : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteGrydka;
    [SerializeField] private List<Plant> _allPlants;
    public RawImage plantunGrydka;
    public Plant plant;
    private int StateOfGrowth;
    public float GrowthAccelerator;
    private bool Growth;
    private float timeGrowthInStage;
    public bool empty;


    private void Start()
    {
        // PlantaPlant();
    }

    public void InitGrydka()
    {
    }
    
    void Update()
    {
        if (Growth)
        {
            if (StateOfGrowth == 3)
            {
                Growth = false;
                //TODO евент что созрели
                return;
            }
            if (timeGrowthInStage + plant.timeGrowth < Time.time)
            {
                StateOfGrowth++;
                timeGrowthInStage = Time.time;
                plantunGrydka.texture = plant.spritePlant[StateOfGrowth];
            } 
        }
    }

    public void PlantaPlant()
    {
        empty = true;
        StateOfGrowth = 0;
        timeGrowthInStage = Time.time;
        Growth = true;
        plant = _allPlants[Random.Range(0, _allPlants.Count)];
        plantunGrydka.texture = plant.spritePlant[0];
        plantunGrydka.gameObject.SetActive(true);
    }
}

public enum ETypePlant
{
    Starch_Nut = 1,
    Mystical_Mushroom = 2
}

[Serializable]
public class Plant
{
    public string namePlant;
    public ETypePlant typePlant;
    public int timeGrowth;
    public List<Texture> spritePlant;
}