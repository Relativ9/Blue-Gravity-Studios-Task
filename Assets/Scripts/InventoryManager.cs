using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUi;

    private bool isInventoryOpen = false;

    public void Inventory(InputAction.CallbackContext inventory)
    {
        if (inventory.performed)
        {
            if (!isInventoryOpen)
            {
                Time.timeScale = 0f;
                isInventoryOpen = true;
                inventoryUi.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                isInventoryOpen = false;
                inventoryUi.SetActive(false);
            }
        }
    }

    public void AddItem(string itemName, int amount, Sprite itemSprite)
    {
        Debug.Log("itemName = " + itemName + "amount = " + amount + "itemSprite = " + itemSprite);
    }
}
