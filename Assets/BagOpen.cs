using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BagOpen : MonoBehaviour
{
    public List<GameObject> habar;
    public List<Texture> texturesPlants;
    private Bag _bag;
   
    private void OnEnable()
    {
       InitBag();
    }

    void Awake()
    {
        _bag = Bag.instance;
    }

    private void InitBag()
    {
        int countSlot = 0;
        if (_bag.starchNut > 0)
        {
            habar[countSlot].gameObject.SetActive(true);
            habar[countSlot].GetComponent<RawImage>().texture = texturesPlants[0];
            habar[countSlot].GetComponentInChildren<TextMeshProUGUI>().text = _bag.starchNut.ToString();
            countSlot++;
        }
        
        if (_bag.mysticalMushroom > 0)
        {
            habar[countSlot].gameObject.SetActive(true);
            habar[countSlot].GetComponent<RawImage>().texture = texturesPlants[1];
            habar[countSlot].GetComponentInChildren<TextMeshProUGUI>().text = _bag.mysticalMushroom.ToString();
            countSlot++;
        }
    }

    private void OnDisable()
    {
        foreach (var h in habar)
        {
            h.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
