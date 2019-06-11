using UnityEngine; 

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private float canJump = 0f;
    public Gaze gaze;
    Animator anim;
    Rigidbody rb;
    int crash = 1;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
       

        if (gameObject.CompareTag("Chicken"))
        {
            Vector3 movement = new Vector3(0.5f * crash, 0.0f, 0.0f);
            gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
            gameObject.transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
           
        }

        if (gaze.activate)
        {
            if (gameObject.CompareTag("Penguin"))
            {
                anim.SetTrigger("jump");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (! (collision.collider.name == "Roads"))
            crash = crash * (-1);
    }
}