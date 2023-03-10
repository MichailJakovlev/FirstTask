using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;

    private NavMeshAgent agent;
    private Camera mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {   
        if(variableJoystick.Vertical != 0 && variableJoystick.Horizontal != 0)
        { 
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            agent.velocity = direction * speed * Time.fixedDeltaTime;
            agent.SetDestination(direction + agent.transform.position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}

