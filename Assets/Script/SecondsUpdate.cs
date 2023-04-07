using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    private float timeStartOffset = 0;
    private bool gotStartTime = false;
    private float speed = .5f;

    private void Update()
    {
        if (!gotStartTime)
        {
            timeStartOffset = Time.realtimeSinceStartup;
            gotStartTime = true;
        }

        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, (Time.realtimeSinceStartup - timeStartOffset) * speed);
        //this.transform.Translate(0f, 0f, .1f);
    }
}
