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

    //Raycast Distance
    private int interactDist = 3;
    private int shootDist = 5;

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
        Quaternion characterRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        character.rotation = characterRotation;

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
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactDist))
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

        if (player.GetComponent<Inventory>().shotCount > 0)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, shootDist))
            {
                if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy _enemy))
                {
                    player.GetComponent<Inventory>().shotCount--;
                    _enemy.StateMachine.SetState(new Enemy.StunState(_enemy));
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Interact Distance
        Gizmos.color = Color.red;
        Vector3 intDirection = transform.TransformDirection(Vector3.forward) * interactDist;
        Gizmos.DrawRay(transform.position, intDirection);

        //Shoot Distance
        Gizmos.color = Color.red;
        Vector3 shootDirection = transform.TransformDirection(Vector3.forward) * shootDist;
        Gizmos.DrawRay(transform.position, shootDirection);
    }
}

public interface IInteraction
{
    public void Activate();
}
