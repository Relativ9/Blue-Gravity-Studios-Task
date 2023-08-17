using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingAnimSync : MonoBehaviour
{

    private Movement moveScript;
    private Animator prefabAnim;
    // Start is called before the first frame update
    void Awake()
    {
        moveScript = FindObjectOfType<Movement>();
        prefabAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        prefabAnim.SetFloat("Horizontal", moveScript.moveInput.x);
        prefabAnim.SetFloat("Vertical", moveScript.moveInput.y);
        prefabAnim.SetBool("IsMoving", moveScript.isMoving);
    }
}
