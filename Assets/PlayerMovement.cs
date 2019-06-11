using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //public int playerSpeed;
    NavMeshAgent agent;
    RaycastHit hit;
    public GameObject exit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        /*if (Camera.main.transform.eulerAngles.x > 345 || Camera.main.transform.eulerAngles.x < 18)
        {
            
            Vector3 tranVector = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
            tranVector.y = 0.96f;
            transform.position = tranVector;
        }*/

        Vector3 reticle = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(reticle, Camera.main.transform.forward, out hit, 100.0f))
        {
            //Move to location that was hit with the raycast
            agent.destination = hit.point;
            if (Camera.main.transform.eulerAngles.x > 80 && Camera.main.transform.eulerAngles.x < 90)
            {
                agent.isStopped = true;
                exit.SetActive(true);
            }
        }
    }
}
