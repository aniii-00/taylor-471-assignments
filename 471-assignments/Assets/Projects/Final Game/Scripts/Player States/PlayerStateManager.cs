using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{

    // -{ States }- \\

    
    public PlayerBaseState currentState;

    [HideInInspector]
    public PlayerRunState runState = new PlayerRunState();
    
    [HideInInspector]
    public PlayerIdleState idleState = new PlayerIdleState();

    [HideInInspector]
    public PlayerWalkState walkState = new PlayerWalkState();
    [HideInInspector]
    public PlayerSneakState sneakState = new PlayerSneakState();


    // -{ Objects }- \\

    [HideInInspector]
    public Vector2 movement;
    
    [SerializeField]
    GameObject cam;
    CharacterController controller;



    

    // -{ SerializeFields }- \\
    [SerializeField]
    float JumpHeight = 1.0f;

    [SerializeField]
    float gravityVal = 9.8f;

    [SerializeField]
    float mouseSensitivity = 100;

    //-{ Number Variables }- \\
    float ySpeed = 0;
    public float default_speed = 5;
    float cameraUpRotation = 0.0f;
    Vector2 mouseMovement;

    Vector3 actual_movement;

    // -{ Bools }- \\

    public bool isSneaking = false;

    public bool isRunning = false;

    public bool hasJumped = false;

   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        SwitchState(idleState);

    }

    // Update is called once per frame
    void Update()
    {

        currentState.UpdateState(this);

    }

    //Handle Input

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
        print("Moving!");
    }

    void OnCrouch()
    {
        if (isSneaking == false)
        {
            isSneaking = true;
        } else
        {
            isSneaking = false;
        }
    }

    void OnSprint(InputValue sprintVal)
    {
        if (sprintVal.isPressed)
        {
            isRunning = true;
        } else
        {
            isRunning = false;
        }
    }

    
       void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();

    }

    // Helper Functions

    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 applied_movement = new Vector3 (moveX, 0, moveZ);

   

        controller.Move(applied_movement * Time.deltaTime * speed);
        
    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
