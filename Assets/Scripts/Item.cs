using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] private string itemName;
    [SerializeField][TextArea] private string itemInfo;
    [SerializeField] private int amount;
    [SerializeField] private Sprite itemSprite;

    private InventoryManager invenManager;

    void Awake()
    {
        invenManager = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int itemCount = invenManager.AddItem(itemName, itemInfo, amount, itemSprite, prefabToSpawn);
            if (itemCount <= 0) Destroy(gameObject);
            else amount = itemCount;
            Destroy(gameObject);
        }

    }
}
