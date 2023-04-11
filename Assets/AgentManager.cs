using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    //private GameObject[] agents;

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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
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
