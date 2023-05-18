using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    //Inputs
    private float horizontalInput;
    private float forwardInput;

    //Movement
    [Range(1, 20)]
    [SerializeField] private float moveSpeed;

    //Jump
    private bool isJump;

    [Range(1, 100)]
    [SerializeField] private float jumpForce;

    //Mouse Look
    [HideInInspector]
    public float mouseSensitivity = 300.0f;
    [HideInInspector]
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    private void Awake()
    {
        if(!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.LogError("This GameObject needs a Rigidbody");
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");

        //Movement
        moveSpeed = 5;

        //Jump
        isJump = true;
        jumpForce = 10;

        //Mouse Look
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");

        ////Forward and backward Inputs
        //if (Input.GetKey("w"))
        //{
        //    transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //}

        //else if (Input.GetKey("s"))
        //{
        //    transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        //}

        ////Left and Right Inputs
        //if (Input.GetKey("a"))
        //{
        //    transform.position += -transform.right * moveSpeed * Time.deltaTime;
        //}

        //else if (Input.GetKey("d"))
        //{
        //    transform.position += transform.right * moveSpeed * Time.deltaTime;
        //}



        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump == true)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJump = false;
            }
        }

        //----------------------------------MOUSELOOK---------------
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }
    }
}
