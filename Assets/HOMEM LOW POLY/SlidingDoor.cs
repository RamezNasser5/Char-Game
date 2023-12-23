using UnityEngine;

public class SlidingDoor : MonoBehaviour
{

    Animator RightAnimator, LeftAnimator;

    void Start()
    {

        RightAnimator = GameObject.Find("RightDoor").GetComponent<Animator>();
        LeftAnimator = GameObject.Find("LeftDoor").GetComponent<Animator>();

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            RightAnimator.SetBool("Opened", true);
            LeftAnimator.SetBool("Opened", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            RightAnimator.SetBool("Opened", false);
            LeftAnimator.SetBool("Opened", false);
        }
    }
}


