using Unity.VisualScripting;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        repeatWidth = 42.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > startPos.x + repeatWidth)
        {
            transform.position = startPos;

        }
    }
}
