using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb; // null - by default nothing is in this variable
    private Camera playerCamera; // null - by default nothing is in this variable

    public bool isGrounded = false;

    private float speed = 10f;
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

    //FixedUpdate() only runs when the physics engine runs

    private void FixedUpdate()

    {
        // New - making a new vector, 3 dimensions xyz
        // the new vector remaps our input, input.x  -> movement on x axis movement.x  input.y  -> movement.z
        // (this is because Y is 'up' in Unity)

        // float y = rb.linearVelocity.y;

        Vector3 movement = new Vector3 (moveInput.x, 0f, moveInput.y * speed);

        // Velocity is the speed of our Character (as a vector)

        rb.AddForce(movement * speed);  // Add force is intensity of the physics // speed variable is set at top

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
