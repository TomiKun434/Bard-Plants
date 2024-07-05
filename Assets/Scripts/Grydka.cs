using System;
using System.Collections.Generic;
using DG.Tweening;
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
    public bool ripe;
    public int levelGrydka;
    

    void Update()
    {
        if (Growth)
        {
            if (StateOfGrowth == 3)
            {
                Growth = false;
                ripe = true;
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

    private void OnMouseDown()
    {
        if (StateOfGrowth == 3)
        {
            StateOfGrowth = 0;
            plantunGrydka.transform.SetParent(Bag.instance.transform);
            plantunGrydka.transform.DOMove(Bag.instance.transform.position, 1).SetEase(Ease.Linear).OnComplete(Test);
        }

        Debug.Log($"Tap in {gameObject}");
    }

    public void Harvesting()
    {
        if (StateOfGrowth == 3)
        {
            StateOfGrowth = 0;
            ripe = false;
            plantunGrydka.transform.SetParent(Bag.instance.transform);
            plantunGrydka.transform.DOMove(Bag.instance.transform.position, 1).SetEase(Ease.Linear).OnComplete(Test);
        }

        Debug.Log($"Harvesting {gameObject}");
    }

    private void Test()
    {
        empty = false;
        plantunGrydka.gameObject.SetActive(false);
        plantunGrydka.transform.SetParent(transform);
        plantunGrydka.transform.localPosition = Vector3.zero;
        Bag.instance.AddPlants(plant.typePlant);
    }

    public void UpgradeGrydka()
    {
        GameManager.instance.PoPUpUpgrade.SetActive(true);
        Debug.Log($"UptgadeGrydka");
    }
}

public enum ETypePlant
{
    Starch_Nut = 1,
    Mystical_Mushroom = 2,
    CrystalNut = 3
}

[Serializable]
public class Plant
{
    public string namePlant;
    public ETypePlant typePlant;
    public int timeGrowth;
    public List<Texture> spritePlant;
}