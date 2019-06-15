using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Gaze : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;
    
    public PlayerMovement movement;
    public NavMeshAgent agent;

    public bool activate = false;
    public bool move = false;
    public int distanceOfRay = 100;
    public RaycastHit _hit;
    public Rigidbody body;


    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
            if (imgGaze.fillAmount == 1)
            {
                activate = true;
            }
        }

        //_hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(ray, out _hit, distanceOfRay))
        {
            if (imgGaze.fillAmount == 1 && _hit.rigidbody.tag == "360")
            {
                SceneManager.LoadScene("360");
            }
            else if (imgGaze.fillAmount == 1 && _hit.rigidbody.tag == "Teleport")
            {
                move = true;
                body = _hit.rigidbody;
            }

        }
    }

    public void GVROn()
    {
        gvrStatus = true;
        agent.isStopped = true;
    }

    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
        activate = false;
        move = false;
        agent.isStopped = false;
    }
}
