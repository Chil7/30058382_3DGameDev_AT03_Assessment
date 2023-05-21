using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Mouse Look
    [HideInInspector]
    public float mouseSensitivity = 300.0f;
    [HideInInspector]
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    private Transform character;

    private void Awake()
    {
        character = transform.root;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Mouse Look
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse look
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        character.rotation = localRotation;

        //Interact
        if (Input.GetMouseButtonDown(0))
        {
            InteractWorldObject();
        }



    }
    public void InteractWorldObject()
    {
        RaycastHit hit;
        Interactables _tempItem;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent<Interactables>(out _tempItem))
            {
                Debug.Log(_tempItem);
            }
        }
    }
}
