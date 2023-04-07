using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    private void Update()
    {
        float speed = .5f;

        // this.transform.Translate(0f, 0f, .1f);
        this.transform.Translate(0f, 0f, Time.deltaTime * speed);
    }
}
