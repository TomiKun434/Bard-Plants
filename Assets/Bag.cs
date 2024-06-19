using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public static Bag instance;

    public int starchNut;
    public int mysticalMushroom;
    
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
    
    void Update()
    {
        
    }
}
