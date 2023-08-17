using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator baseAnim;
    private Animator underwearAnim;

    private Vector2 moveInput;
    
    
    public bool isMoving;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        baseAnim = GetComponent<Animator>();
        underwearAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(moveInput.x != 0 || moveInput.y != 0)
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        playerRb.velocity = moveInput * moveSpeed;
    }

    private void OnMove(InputValue move)
    {
        moveInput = move.Get<Vector2>();
    }
}
