using UnityEngine;
using UnityEngine.InputSystem;
public class RollABallPlayer : MonoBehaviour
{
    Vector2 m;
    Rigidbody rb; 
    public GameObject cube;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start  ()
    {
        m = new Vector2(0,0);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_direct = m.x;
        float z_direct = m.y;
        Vector3 actual_movement = new Vector3(x_direct, 0, z_direct);
        print(actual_movement);

        rb.AddForce(actual_movement);
    }

    void OnMove(InputValue movement)
    {
        m = movement.Get<Vector2>();
    }

}
