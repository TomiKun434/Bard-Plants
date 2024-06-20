using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public static Bag instance;
    public GameObject canvasOpenBag;

    public int starchNut;
    public int mysticalMushroom;
    public int plant3;
    public int plant4;
    public int plant5;
    public int plant6;
    public int plant7;
    public int plant8;
    public int plant9;
    
    void Start()
    {
        if (instance == null) { 
            instance = this; 
        } else if(instance == this)
        { 
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        // InitializeManager();
    }

    public void AddPlants(ETypePlant type)
    {
        switch (type)
        {
           case ETypePlant.Starch_Nut:
               starchNut++;
               break;
           case ETypePlant.Mystical_Mushroom:
               mysticalMushroom++;
               break;
        } 
    }

    private void OnMouseDown()
    {
        canvasOpenBag.SetActive(true);
    }

    void Update()
    {
        
    }
}
