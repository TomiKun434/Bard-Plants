using System.Collections.Generic;
using UnityEngine;

public class Orders : MonoBehaviour
{
    public List<Order> orders;


    private void Start()
    {
        orders[0].gameObject.SetActive(true);
        orders[0].InitOrder(ETypePlant.Starch_Nut, 5);
    }

    public bool DeliveryOrder()
    {
        var allActive = orders.FindAll(c => c.gameObject.activeSelf);
        foreach (var ord in allActive)
        {
            if (!ord.completed)
            {
                return false;
            }
        }
        return true;
    }
}