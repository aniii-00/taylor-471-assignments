using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    int health = 5;
    private Transform target;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime );
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            health -= 1;
            Destroy(other.gameObject);
        }
        
    }
}
