using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class StartGame : MonoBehaviour
{
    public GameObject Button;
    public Gaze gaze;
    public NavMeshAgent agent;

    void Start()
    {
        agent.isStopped = true;
        if (PlayerPrefs.GetString("SceneLoaded") == "true")
        {
            agent.isStopped = false;
            Button.SetActive(false);
        }
    }

    public void Game()
    {
        Button.SetActive(false);
        agent.isStopped = false;
    }

    public void Exit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void Update()
    {
        if (gaze.activate)
        {
            ExecuteEvents.Execute(Button, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
    }
}
