using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    float timer;
    float totaltime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>totaltime)
        {
            PlayerPrefs.SetString("SceneLoaded", "true");
            SceneManager.LoadScene("main");
        }
    }
}
