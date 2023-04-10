using UnityEngine;

public class FollowWayPoint : MonoBehaviour
{
    public GameObject[] wayPoints;
    private int currentWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 10f;
    public float lookAhead = 10f;
    private GameObject tracker;

    // Start is called before the first frame update
    private void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }

    private void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > lookAhead)
            return;
        if (Vector3.Distance(tracker.transform.position, wayPoints[currentWP].transform.position) < 3)
            currentWP++;
        if (currentWP >= wayPoints.Length)
            currentWP = 0;
        tracker.transform.LookAt(wayPoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed + 2) * Time.deltaTime);
    }

    // Update is called once per frame
    private void Update()
    {
        /*if (Vector3.Distance(this.transform.position, wayPoints[currentWP].transform.position) < 3)
            currentWP++;
        if (currentWP >= wayPoints.Length)
            currentWP = 0;
        // this.transform.LookAt(wayPoints[currentWP].transform);
        */

        ProgressTracker();

        Quaternion looatWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(transform.rotation, looatWP, rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
