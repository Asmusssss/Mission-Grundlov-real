using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class SimpleController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float crouchSpeed = 2.5f;
    private float currentSpeed = 0;
    public float NoiseLevel = 0;
    private CharacterController controller;
    private bool isGrounded = false;
    public Animator animator;

    private Vector3 moveDirection = Vector3.zero;


    [Tooltip("Which things count as buttons?")]
    public LayerMask buttonLayer;
    // Button detection
    private bool onButton = false;
    private Button lastSeenButton = null;


 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = moveSpeed;

      
        NoiseLevel = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we're on the ground
        isGrounded = GroundControl();

        

        
        if(moveDirection.magnitude > 2.5)
        {
            animator.SetBool("isWalking",true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Get user input (old input system)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        bool wantJump = Input.GetButtonDown("Jump");
        bool wantCrouch = Input.GetKeyDown(KeyCode.LeftShift);
        // Reset y velocity when we hit the ground
        if (isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0;
        }

        if(moveDirection.magnitude > 0.5)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // Handle movement on the ground
        if (isGrounded)
        {
            moveDirection = new Vector3(h, moveDirection.y, v).normalized * currentSpeed;

            // Face in the move direction
            if (h != 0 || v != 0)
            {
                transform.forward = new Vector3(h, 0f, v);
            }

            if (Input.GetKey(KeyCode.LeftShift) && moveDirection.magnitude > 0.5f)
            {
                Debug.Log("Crouching");
                currentSpeed = crouchSpeed;
                NoiseLevel = 1;
                animator.SetBool("isCrouching", true);
            }
            else
            {
                Debug.Log("Not crouching");
                currentSpeed = moveSpeed;
                NoiseLevel = 2;
                animator.SetBool("isCrouching", false);
            }
            if(moveDirection.magnitude == 0)
            {
                NoiseLevel = 0;
            }
        }

        // Handle jumping
        if (isGrounded && wantJump)
        {
            moveDirection.y = Mathf.Sqrt(2f * gravity * jumpHeight);
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move
        controller.Move(moveDirection * Time.deltaTime);

    }

  
    // Built-in ground check is bad, so use raycast instead
    private bool GroundControl()
    {
        return Physics.Raycast(
            transform.position + controller.center,                     // from the middle of the controller...
            Vector3.down,                                               // ...pointing downwards...
            controller.bounds.extents.y + controller.skinWidth + 0.2f); // ... to the bottom of the controller.
    }

    
}
