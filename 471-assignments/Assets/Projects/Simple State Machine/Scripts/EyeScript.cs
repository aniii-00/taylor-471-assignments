using UnityEngine;

public class EyeScript : MonoBehaviour
{
    // -{ Serialized Fields }- \\
    [SerializeField]
    GameObject eyelid;


    // -{ Simple Variables }- \\

    
    // -{ States }- \\
    private enum State
    {
        Found,
        Lost,
    }

    // -{ Start State }- \\
    private State currentState = State.Lost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
       switch(currentState)
        {
            case State.Found:
                OnFound();
                break;
            case State.Lost:
                OnLost();
                break;
        }
        
    }

    void OnFound()
    {
        // -{ What do we do when player is in sight? }- \\


        // -{ On what condition do we switch states? }- \\

        GameObject obstacle = CheckForward();

         if (obstacle == null)
        {
            currentState = State.Lost;
        }
    }

    void OnLost()
    {
        // -{ What do we do when player is not in sight? }- \\
        

        // -{ On what condition do we switch states? }- \\
        
        GameObject obstacle = CheckForward();

        if (obstacle != null)
        {
            
            print("switching");
            currentState = State.Found;
        }
    }

    // -{ Checking if player is in sight }- \\
    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.magenta);

        if(Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            FirstPersonController player = hit.transform.gameObject.GetComponent<FirstPersonController>();

            if (player!= null)
            {
                print(hit.transform.name);
                return hit.transform.gameObject;
            }
        }
        return null;
    }

   
}

