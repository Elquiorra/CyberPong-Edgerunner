using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CyberController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float boostForce;
    [SerializeField] private float rollRotationSpeed;
    [SerializeField] private float yampPitchRotationSpeed;
    [SerializeField] private bool jump;
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private Vector3 thruster;
    [SerializeField] private GameObject thrustFx;
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
        Fall();
        getBoosterDir();
        
        horizontalInput = Input.GetAxis("P1_Horizontal");
        verticalInput = Input.GetAxis("P1_Vertical");
        isGrounded = CheckIsGrounded();

        if (jump)
        {
            Debug.Log("Aku Jump");
            jump = false;
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (!isGrounded)
        {
            AerialCarControl();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
            Debug.Log(jump);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-Vector3.forward * speed);
        }
        
        if (Input.GetMouseButton(0))
        {
            rb.AddRelativeForce(thruster * boostForce);
            thrustFx.SetActive(true);
        }
        else
        {
            thrustFx.SetActive(false);
        }

        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0f;
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    private void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed);
        }
    }

    private void Fall()
    {

    }

    private void AerialCarControl()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back, rollRotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward, rollRotationSpeed * Time.deltaTime);
        }

        if (verticalInput > 0)
        {
            transform.Rotate(Vector3.back, yampPitchRotationSpeed * Time.deltaTime);
        }
        else if (verticalInput < 0)
        {
            transform.Rotate(Vector3.forward, yampPitchRotationSpeed * Time.deltaTime);
        }

        if (horizontalInput > 0)
        {
            transform.Rotate(Vector3.up, yampPitchRotationSpeed * Time.deltaTime);
        }
        else if (horizontalInput < 0)
        {
            transform.Rotate(Vector3.down, yampPitchRotationSpeed * Time.deltaTime);
        }
    }
    public bool CheckIsGrounded()
    {
        RaycastHit hit;
        bool grounded;
        if (Physics.Raycast(transform.position, -transform.up, out hit, groundedCheckDistance))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        Debug.DrawRay(transform.position, -transform.up.normalized * groundedCheckDistance, Color.green);
        return grounded;
    }

    private void getBoosterDir()
    {
        thruster = Vector3.forward;
    }
}
