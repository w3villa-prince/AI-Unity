using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    private void LateUpdate()
    {
        float speed = .5f;
        //this.transform.Translate(0f, 0f, .1f);
        this.transform.Translate(0f, 0f, Time.deltaTime * speed);
    }
}
