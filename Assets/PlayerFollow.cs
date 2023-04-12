using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    /* public GameObject[] wayPoint;*/
    //private Vector3 randomPos = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));

    private int wPCount = 0;

    public NavMeshAgent agent;

    private Animator anim;
    private GameObject player;
    private bool tiggerExit = true;

    // Start is called before the first frame update
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        // agent.SetDestination(player.transform.position);

        if (agent.remainingDistance < 2)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        if (tiggerExit)
        {
            agent.SetDestination(EnemyPOs());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            tiggerExit = false;
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            agent.SetDestination(player.transform.position);
            player = null;
            tiggerExit = true;
        }
        //agent.SetDestination(agent.transform.position);
    }

    private Vector3 EnemyPOs()
    {
        float rx = Random.Range(-20.0f, 20.0f) + agent.transform.position.x;
        float rz = Random.Range(-20.0f, 20.0f) + agent.transform.position.z;
        return new Vector3(rx, 0, rz);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player != null)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
}
