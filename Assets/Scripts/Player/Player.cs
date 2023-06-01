using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Items;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private AudioSource audioSource;

    //SwordEquipped
    [SerializeField] private GameObject swordEquipped;

    //Movement
    [Range(1, 20)]
    [SerializeField] private float sprintSpeed = 6f;
    [Range(1, 20)]
    [SerializeField] private float walkSpeed = 2.0f;
    private float currentSpeed;

    private Vector3 motion;
    private CharacterController controller;
    private float velocity = 0;

    [Range(0.1f, 10f)]
    [SerializeField] private float jumpForce;
    [Range(0.1f, 10f)]
    [SerializeField] private float gravity;



    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        if (!TryGetComponent<CharacterController>(out controller))
        {
            Debug.LogError("This object needs a Character Controller");
        }
        if (!TryGetComponent<AudioSource>(out audioSource))
        {
            Debug.LogError("This object needs an Audio Source");
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Inventory playerInventory = this.GetComponent<Inventory>();

        //SwordEquipped
        if (playerInventory.swordObtained == true)
        {
            swordEquipped.SetActive(true);
        }
        else
        {
            swordEquipped.SetActive(false);
        }

        //Movement
        motion = Vector3.zero;
        ApplyMovement();

        if (controller.isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                velocity = jumpForce;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) == true)
            {
                //check to see speed is not equal to sprint speed
                if (currentSpeed != sprintSpeed)
                {
                    currentSpeed = sprintSpeed;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                //change to walk speed
                if (currentSpeed != walkSpeed)
                {
                    currentSpeed = walkSpeed;
                }
            }
        }
        else
        {
            velocity -= gravity * Time.deltaTime;
        }

        //Sound
        if (controller.isGrounded == true && controller.velocity.magnitude > 2f && audioSource.isPlaying == false)
        {
            audioSource.volume = Random.Range(0.8f, 1f);
            audioSource.pitch = Random.Range(0.8f, 1.1f);
            audioSource.Play();
        }

    }

    void ApplyMovement()
    {
        motion += transform.forward * Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
        motion += transform.right * Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
        motion.y += velocity;

        if (controller.enabled)
        {
            controller.Move(motion);
        }
    }
}
