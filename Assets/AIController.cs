using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;

    // private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        // anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {/*
        if (agent.remainingDistance < 2)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }*/
    }
}
