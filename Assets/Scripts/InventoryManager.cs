using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUi;

    public bool isInventoryOpen = false;
    public itemSlot[] itemSlot;

    public void Inventory(InputAction.CallbackContext inventory)
    {
        if (inventory.performed)
        {
            if (!isInventoryOpen)
            {
                Time.timeScale = 0f;
                isInventoryOpen = true;
                inventoryUi.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                isInventoryOpen = false;
                inventoryUi.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public int AddItem(string itemName, string itemInfo, int amount, Sprite itemSprite, GameObject prefabToSpawn)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(!itemSlot[i].isFull && itemSlot[i].itemName == itemName || itemSlot[i].amount == 0)
            {
                int itemCount = itemSlot[i].AddItem(itemName, itemInfo, amount, itemSprite, prefabToSpawn);
                if (itemCount > 0)
                {
                    itemCount = AddItem(itemName, itemInfo, itemCount, itemSprite, prefabToSpawn);
                }
                return itemCount;
            }
        }
        return amount;
    }
}
