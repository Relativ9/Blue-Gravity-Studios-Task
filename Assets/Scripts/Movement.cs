using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator baseAnim;

    public Vector2 moveInput;
    
    
    public bool isMoving;
    [SerializeField] private float moveSpeed;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        baseAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(moveInput.x != 0 || moveInput.y != 0) isMoving = true;
       else isMoving = false;
       
        baseAnim.SetFloat("Horizontal", moveInput.x);
        baseAnim.SetFloat("Vertical", moveInput.y);
        baseAnim.SetBool("IsMoving", isMoving);
    }

    private void FixedUpdate()
    {
        playerRb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext move)
    {
        moveInput = move.ReadValue<Vector2>();
    }
}
