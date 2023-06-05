using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using Items;

public class Player : MonoBehaviour
{
    private AudioSource audioSource;

    //SwordEquipped
    [SerializeField] private GameObject swordEquipped;

    //Movement
    PlayerControls controls;

    [Range(1, 20)]
    [SerializeField] private float walkSpeed = 4f;

    private float currentSpeed;

    private Vector3 playerMotion;
    private Vector2 motion;
    private CharacterController controller;
    private float velocity = 0;

    [Range(0.1f, 10f)]
    [SerializeField] private float jumpForce;
    [Range(0.1f, 10f)]
    [SerializeField] private float gravity;

    



    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        controls = new PlayerControls();

        //Keyboard Movement
        controls.Gameplay.MovementKeyboard.performed += ctx => motion = ctx.ReadValue<Vector2>();
        controls.Gameplay.MovementKeyboard.canceled += ctx => motion = Vector2.zero;

        //Gamepad Movement
        controls.Gameplay.MovementGamepad.performed += ctx => motion = ctx.ReadValue<Vector2>();
        controls.Gameplay.MovementGamepad.canceled += ctx => motion = Vector2.zero;

        //Jump
        controls.Gameplay.JumpKeyboard.performed += ctx => Jump();
        controls.Gameplay.JumpGamepad.performed += ctx => Jump();


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
        playerMotion = Vector3.zero;
        ApplyMovement();


        if (controller.isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;

            

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

        playerMotion += transform.forward * motion.y * currentSpeed * Time.deltaTime;
        playerMotion += transform.right * motion.x * currentSpeed * Time.deltaTime;
        playerMotion.y += velocity;

        if (controller.enabled)
        {
            controller.Move(playerMotion);
        }
    }

    void Jump()
    {
        if (controller.isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;
            velocity = jumpForce;

        }
    }

    public void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    public void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
