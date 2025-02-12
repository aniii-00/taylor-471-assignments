using UnityEngine;
using UnityEngine.InputSystem;
public class FirstPersonController : MonoBehaviour
{
//  -{ Variables}-    
    Vector2 movement;
    Vector2 mouseMovement;
    float cameraUpRotation = 0.0f;
    CharacterController controller;
 

// -{Serialize Fields}-


    [SerializeField]
    float speed = 2.0f;
    [SerializeField]
    float mouseSensitivity = 100;

    [SerializeField]
    GameObject BulletSpawner;

    [SerializeField]
    GameObject cam;

    
    [SerializeField]
    GameObject Bullet;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera
        float lookX= mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float lookY= mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= lookY;

        cameraUpRotation = Mathf.Clamp(cameraUpRotation , -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation,0,0);


       //Movement
        transform.Rotate(Vector3.up * lookX);
        float moveX = movement.x;
        float moveZ = movement.y;
        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);
        controller.SimpleMove(actual_movement * speed);


    
       
    }

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }

    void OnAttack()
    {
        Instantiate(Bullet, BulletSpawner.transform.position, BulletSpawner.transform.rotation);
    }
}
