using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private string itemName;
    [SerializeField][TextArea] private string itemInfo;
    [SerializeField] private int amount;
    [SerializeField] private Sprite itemSprite;

    private InventoryManager invenManager;
    // Start is called before the first frame update
    void Awake()
    {
        invenManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            int itemCount = invenManager.AddItem(itemName, itemInfo, amount, itemSprite);
            if (itemCount <= 0) Destroy(gameObject);
            else amount = itemCount;
            Destroy(gameObject);
        }

    }
}
