using UnityEngine;

public class play_ : MonoBehaviour

{
    public GameObject starter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(false);
            print("Key pressed");
        }
    }

   
}
