using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private GameObject player;

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
        if (Input.GetKeyDown(KeyCode.E))
        { 
            InteractWorldObject();
        }

        //Shoot Taser
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void InteractWorldObject()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            if (hit.collider.gameObject.TryGetComponent<IInteraction>(out IInteraction inter))
            {
                Debug.Log(hit);
                inter.Activate();
            }
        }
    }

    public void Shoot()
    {
        player = GameObject.FindWithTag("Player");
        RaycastHit hit;

        if (player.GetComponent<Inventory>().taserShots > 0)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
            {
                if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy _enemy))
                {
                    player.GetComponent<Inventory>().taserShots--;
                    Debug.Log(player.GetComponent<Inventory>().taserShots + " shots left");
                    _enemy.StateMachine.SetState(new Enemy.StunState(_enemy));
                }
            }
        }
    }
}

public interface IInteraction
{
    public void Activate();
}
