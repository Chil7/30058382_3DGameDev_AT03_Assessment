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
    public int interactDist = 3;
    public int attackDist = 2;

    private Transform character;

    private void Awake()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
            Attack();
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

    public void Attack()
    {
        player = GameObject.FindWithTag("Player");
        Inventory playerInventory = player.GetComponent<Inventory>();
        RaycastHit hit;

        if (playerInventory.swordObtained == true)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, attackDist))
            {
                if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy _enemy))
                {
                    FindObjectOfType<AudioManager>().Play("SwordSlash");
                    playerInventory.swordObtained = false;
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
        Vector3 shootDirection = transform.TransformDirection(Vector3.forward) * attackDist;
        Gizmos.DrawRay(transform.position, shootDirection);
    }
}

public interface IInteraction
{
    public void Activate();
}
