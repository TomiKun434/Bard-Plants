using UnityEngine;

public class Customer : MonoBehaviour
{
    public Orders orders;
    public int expa;

    void Start()
    {
        orders = GetComponentInChildren<Orders>();
        orders.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (orders.DeliveryOrder())
        {
            Debug.Log($"Add Expa {expa}");
            gameObject.SetActive(false);
        }
    }
}