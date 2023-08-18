using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, ISelectHandler
{
    public string itemName;
    public string itemInfo;
    public int amount;
    public int maxStack;
    public Sprite itemSprite;
    public Sprite emptySprite;
    public bool isFull;

    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Image itemImage;


    public Image itemInfoImage;
    public TMP_Text itemNameText;
    public TMP_Text itemInfoText;

    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amount <= 0) amountText.enabled = false;
        else amountText.enabled = true;
    }

    public int AddItem(string itemName, string itemInfo, int amount, Sprite itemSprite)
    {
        if (isFull)
        {
            return amount;
        }

        this.itemName = itemName;

        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        this.itemInfo = itemInfo;


        this.amount += amount;
        if (this.amount >= maxStack)
        {
            amountText.text = maxStack.ToString();
            amountText.enabled = true;
            isFull = true;
            int extraItems = this.amount - maxStack;
            this.amount = maxStack;
            return extraItems;
        }

        amountText.text = this.amount.ToString();
        amountText.enabled = true;
        return 0;
    }

    public void OnSelect(BaseEventData eventData)
    {
        itemNameText.text = itemName;
        itemInfoText.text = itemInfo;
        itemImage.sprite = itemSprite;

        if (itemImage.sprite == null) itemImage.sprite = emptySprite;
    }
}
