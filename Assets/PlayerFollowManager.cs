using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollowManager : MonoBehaviour
{
    public GameObject player;
    public List<NavMeshAgent> agent = new List<NavMeshAgent>();

    // Start is called before the first frame update
    private void Start()
    {
        GameObject[] a = GameObject.FindGameObjectsWithTag("AI");

        foreach (GameObject go in a)
        {
            agent.Add(go.GetComponent<NavMeshAgent>());
        }
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (NavMeshAgent a in agent)
        {
            //a.GetComponent<AIController>().agent.SetDestination(hit.point);

            a.SetDestination(player.transform.position);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(player.transform.position  /*Input.mousePosition*/), out hit, 100))
            {
                foreach (NavMeshAgent a in agent)
                {
                    //a.GetComponent<AIController>().agent.SetDestination(hit.point);

                    a.SetDestination(hit.point);
                }
            }
        }
    }
}
