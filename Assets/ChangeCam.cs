using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera maincam;
    public Camera incam;
    public Gaze gaze;
    float timer;
    public float totalTime = 15;
    bool inside;

    private void Start()
    {
        maincam.enabled = true;
        incam.enabled = false;
        inside = false;
        timer = 0;
    }

    public void Update()
    {
        if (inside)
        {
            timer += Time.deltaTime;
        }
    }

    public void Final()
    {
        if (!inside)
        {
            Debug.Log("Eide");
            Change();
        }
        else if (inside)
        {
            Debug.Log("edo");
            if (timer > totalTime)
            {
               
                timer = 0;
                Change();
            }
        }
    }

    public void Change()
    {
        maincam.enabled = !maincam.enabled;
        incam.enabled = !incam.enabled;
        inside = !inside;
    }
}
