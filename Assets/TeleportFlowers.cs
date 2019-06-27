using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFlowers : MonoBehaviour
{
    public Gaze gaze;
    public GameObject player;
    float[] dist = new float[5];
    int i = 0;
    private TeleportFlowers flower;
    float min = 1000;

    void Update()
    {
        if (gaze.move)
        {
            CalculateDist(gaze.body);
            player.transform.position = (new Vector3(flower.gameObject.transform.position.x,
                    player.transform.position.y, flower.gameObject.transform.position.z));
        }
    }

    private void CalculateDist(Rigidbody body)
    {
        foreach (TeleportFlowers tp in FindObjectsOfType<TeleportFlowers>())
        {

            dist[i] = Mathf.Sqrt(Mathf.Pow(body.transform.position.x - tp.gameObject.transform.position.x, 2f) +
                        Mathf.Pow(body.transform.position.z - tp.gameObject.transform.position.z, 2f));
            if (dist[i] < min && dist[i] > 0)
            {
                min = dist[i]; 
                flower = tp;
            }
            i++;
        }
        i = 0;

    }


}
