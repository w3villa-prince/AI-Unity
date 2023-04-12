using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void LateUpdate()
    {
        transform.position = player.position;
    }
}
