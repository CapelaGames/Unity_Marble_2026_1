using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb; // null - by default nothing is in this variable
    private Camera playerCamera; // null - by default nothing is in this variable

    public bool isGrounded = false;

    private float speed = 100f;
    private float jumpSpeed = 500f;

    private Vector2 moveInput;


    void Start()
    {

        rb = GetComponent<Rigidbody>();  // GetComponent looks on the GameObject - check if we have a Rigidbody setup/added to object
        playerCamera = Camera.main; // Camera.main gets access to the main camera

    }

    // Update is called once per frame
    private void Update()
    {
        
        if(Input.GetKeyDown("space"))
        {
            Debug.Log("Hit space");
            OnJump();
        }

    }

    private void OnJump()

    {
        Debug.Log("Trying to jump");
        if (isGrounded == true)
        {
            Debug.Log("Jumped");
            rb.AddForce(Vector3.up * jumpSpeed); // Up means +1 on Y axis - up positive on Y axis aka. 0,1,0 (y is middle number)
                                                 // jumpSpeed variable is set at the top of script
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); // check your position on the axis?
    }


    private void FixedUpdate()
    {
        // Get the camera's forward and right vectors
        Vector3 camForward = playerCamera.transform.forward;
        Vector3 camRight = playerCamera.transform.right;

        // Flatten them so the player doesn't move up/down when the camera tilts
        camForward.y = 0;
        camRight.y = 0;

        //Build movement relative to the camera's orientation
        Vector3 movement = (camRight * moveInput.x) + (camForward * moveInput.y);

        rb.AddForce(movement * speed); 

    }

    private void OnCollisionStay(Collision other)
    {

        if (other.gameObject.tag == "Ground")

        {

            isGrounded = true;

        }

    }

    private void OnCollisionExit(Collision other)
   
    {

        if (other.gameObject.tag == "Ground")

        {

            isGrounded = false;
        
        }

    }

}
