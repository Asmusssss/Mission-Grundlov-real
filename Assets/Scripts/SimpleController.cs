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

    [Tooltip("Which things count as buttons?")]
    public LayerMask buttonLayer;

    private Vector3 moveDirection = Vector3.zero;

    public Animator animator;

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

        Debug.Log(moveDirection);

        if(moveDirection.magnitude > 0.5)
        {
            animator.SetBool("isWalking",true);
        }
        else
        {
            animator.SetBool("isWalking",false);
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

        // Handle movement on the ground
        if (isGrounded)
        {
            moveDirection = new Vector3(h, moveDirection.y, v).normalized * currentSpeed;

            // Face in the move direction
            if (h != 0 || v != 0)
            {
                transform.forward = new Vector3(h, 0f, v);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("Crouching");
                currentSpeed = crouchSpeed;
                NoiseLevel = 1;
            }
            else
            {
                Debug.Log("Not crouching");
                currentSpeed = moveSpeed;
                NoiseLevel = 2;
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

    // Look for a button under our feet.
    private void FindButton()
    {
        // Make a ray that points down
        Ray downRay = new Ray(transform.position + Vector3.up, Vector3.down);
        RaycastHit hit;

        // Check if it hit a button
        if (Physics.Raycast(downRay, out hit, 10f, buttonLayer))
        {
            // We only act the first time we touch a given button
            if (!onButton)
            {
                OnButtonPress(hit.collider.gameObject);
                onButton = true; // Ensures we only do one button press
            }
        }
        else // If we are not standing on a button, reset onButton
        {
            if (onButton && lastSeenButton != null)
            {
                lastSeenButton = null;
            }
            onButton = false;
        }
    }

    // When we are on a button, call its OnHit method
    private void OnButtonPress(GameObject button)
    {
        Button ButtonScript = button.GetComponent<Button>();
        lastSeenButton = ButtonScript;
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
