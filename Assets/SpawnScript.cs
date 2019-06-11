using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] SpawnPoints = new Transform[3];
    float[] distance = new float[3];
    public Gaze gaze;
    public GameObject player;
    private int i = 0;
    private float min = 10000f;
    private int element = 0;

    public void Update()
    {
        if (gaze.move)
        {
            Debug.Log("spawns"+SpawnPoints.Length);

            //int element = Random.Range(0, SpawnPoints.Length);
            //Debug.Log(element);
            foreach (Transform point in SpawnPoints)
            {
                distance[i] = Mathf.Sqrt( Mathf.Pow(point.transform.position.x - gameObject.transform.position.x, 2f)+ Mathf.Pow(point.transform.position.z - gameObject.transform.position.z, 2f));
                if (distance[i]<min)
                {
                    int element = i;
                }
                i++;
            }

            Debug.Log("ele"+element);
            player.transform.position = (new Vector3(SpawnPoints[element].position.x,player.transform.position.y,SpawnPoints[element].position.z));
            i = 0;
        }
    }
}
