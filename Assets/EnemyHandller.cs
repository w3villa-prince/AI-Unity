using UnityEngine;

public class EnemyHandller : MonoBehaviour
{
    private float point = 0;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            point++;
            Debug.Log(point);
        }
    }
}
