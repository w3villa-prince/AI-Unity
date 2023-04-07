using UnityEngine;

public class FixedUpdateMove : MonoBehaviour
{
    private void FixedUpdate()
    {
        float speed = .5f;
        //this.transform.Translate(0f, 0f, .1f);
        this.transform.Translate(0f, 0f, Time.deltaTime * speed);
    }
}
