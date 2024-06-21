using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public List<Grydka> allGrydka;
    public List<Texture> sptiTexturesPlant;

    public GameObject PoPUpUpgrade;
    // public List<Customer> customers;

    void Start()
    {
        if (instance == null) { 
            instance = this; 
        } else if(instance == this)
        { 
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        CustomersSpawn();
        // InitializeManager();
    }

    private void CustomersSpawn()
    {
        // customers[0].gameObject.SetActive(true);
    }
    void Update()
    {
        
    }
}
