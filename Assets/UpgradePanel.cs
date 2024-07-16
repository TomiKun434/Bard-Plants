using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    public List<UpgradeGrydkaCfg> upgradeGrydkaCfgs;
    public Image imageFrom;
    public TextMeshProUGUI textLevFrom;
    public TextMeshProUGUI textCountPlantsFrom;
    
    public Image imageBefore;
    public TextMeshProUGUI textLevBefore;
    public TextMeshProUGUI textCountPlantsBefore;

    private Grydka _currentGrydka;
    
    public void Init(int lev, Grydka grydka)
    {
        _currentGrydka = grydka;
        var fromGrydka = upgradeGrydkaCfgs[lev - 1];
        var beforeGrydka = upgradeGrydkaCfgs[lev];
        imageFrom.sprite = fromGrydka.sprite;
        textLevFrom.text = fromGrydka.textLev;
        textCountPlantsFrom.text = fromGrydka.textCountPlants;

        imageBefore.sprite = beforeGrydka.sprite;
        textLevBefore.text = beforeGrydka.textLev;
        textCountPlantsBefore.text = beforeGrydka.textCountPlants;
    }

    public void Upgrade()
    {
        _currentGrydka.ApplyUpgrade();
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public class UpgradeGrydkaCfg
{
    public int Level;
    public Sprite sprite;
    public string textLev;
    public string textCountPlants;
    public int cost;

}