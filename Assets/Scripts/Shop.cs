using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shop : MonoBehaviour
{

    public Transform player;
    public GameObject PressE;

    [SerializeField] private GameObject inventoryUi;
    [SerializeField] private GameObject shopUi;

    private InventoryManager invenManager;

    private bool inShopRange;
    // Start is called before the first frame update
    void Awake()
    {
        invenManager = FindObjectOfType<InventoryManager>();
        PressE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RadiusDetection();
    }

    private void RadiusDetection()
    {
        if(Vector2.Distance(player.position, this.transform.position) <= 2f)
        {
            PressE.SetActive(true);
            inShopRange = true;
        } else
        {
            PressE.SetActive(false);
            inShopRange = false;
        }
    }

    public void OpenShop(InputAction.CallbackContext openShop)
    {
        if(inShopRange)
        {
            if (!invenManager.isInventoryOpen)
            {
                Time.timeScale = 0f;
                invenManager.isInventoryOpen = true;
                inventoryUi.SetActive(true);
                shopUi.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                invenManager.isInventoryOpen = false;
                inventoryUi.SetActive(false);
                shopUi.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
