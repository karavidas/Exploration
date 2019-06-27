using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    RaycastHit hit;
    public GameObject exit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
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
