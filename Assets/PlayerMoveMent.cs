using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveMent : MonoBehaviour
{
    public NavMeshAgent player;

    // Start is called before the first frame update
    private void Start()
    {
        player = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                player.SetDestination(hit.point);
            }
        }
    }
}
