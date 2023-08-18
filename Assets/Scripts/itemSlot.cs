using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public string itemName;
    public string itemInfo;
    public GameObject prefabToSpawn;
    public int amount;
    public int maxStack;
    public Sprite itemSprite;
    public Sprite emptySprite;
    public bool isFull;


    public bool isEquipped;
    public GameObject prefab;

    [SerializeField] private Transform player;

    [SerializeField] private TMP_Text amountText;
    [SerializeField] private Image itemImage;


    public Button equip;
    [SerializeField] private TMP_Text buttonText;

    public Image itemInfoImage;
    public TMP_Text itemNameText;
    public TMP_Text itemInfoText;
    

    public bool isSelected;

    void Start()
    {
        equip.interactable = false;
    }

    void Update()
    {
        if (amount <= 0) amountText.enabled = false;
        else amountText.enabled = true;
    }

    public int AddItem(string itemName, string itemInfo, int amount, Sprite itemSprite, GameObject prefabToSpawn)
    {
        if (isFull)
        {
            return amount;
        }

        this.itemName = itemName;

        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        this.prefabToSpawn = prefabToSpawn;
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
        equip.onClick.AddListener(EquipButton);
        itemNameText.text = itemName;
        itemInfoText.text = itemInfo;
        itemInfoImage.sprite = itemSprite;

        if (itemImage.sprite == null) itemImage.sprite = emptySprite;

        if (itemName == null)
        {
            equip.interactable = false;
            return;
        }

        if (itemName.Contains("Equipment"))
        {
            equip.interactable = true;

            if (!isEquipped) buttonText.text = "Equip";
            else buttonText.text = "Unequip";

        }
        else
        {
            equip.interactable = false;
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        itemNameText.text = null;
        itemInfoText.text = null;
        itemInfoImage.sprite = null;
    }

    public void EquipButton()
    {
        if (prefabToSpawn != null)
        {
            if(!isEquipped)
            {
                isEquipped = true;
                prefab = Instantiate(prefabToSpawn, Vector2.zero, Quaternion.identity);
                prefab.transform.parent = player;
                prefab.transform.localPosition = Vector2.zero;
            } else
            {
                isEquipped = false;
                Destroy(prefab);
            }
        }
        equip.onClick.RemoveListener(EquipButton);
    }
}
