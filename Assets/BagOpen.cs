using System.Collections.Generic;
using TMPro;
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
        if (Reference.GameModel.StarchNut.Value > 0)
        {
            habar[countSlot].gameObject.SetActive(true);
            habar[countSlot].GetComponent<RawImage>().texture = texturesPlants[0];
            habar[countSlot].GetComponentInChildren<TextMeshProUGUI>().text =
                Reference.GameModel.StarchNut.Value.ToString();
            countSlot++;
        }

        if (Reference.GameModel.MysticalMushroom.Value > 0)
        {
            habar[countSlot].gameObject.SetActive(true);
            habar[countSlot].GetComponent<RawImage>().texture = texturesPlants[1];
            habar[countSlot].GetComponentInChildren<TextMeshProUGUI>().text =
                Reference.GameModel.MysticalMushroom.Value.ToString();
            countSlot++;
        }

        if (Reference.GameModel.CrystalNut.Value > 0)
        {
            habar[countSlot].gameObject.SetActive(true);
            habar[countSlot].GetComponent<RawImage>().texture = texturesPlants[2];
            habar[countSlot].GetComponentInChildren<TextMeshProUGUI>().text =
                Reference.GameModel.CrystalNut.Value.ToString();
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