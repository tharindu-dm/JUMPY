using UnityEngine;

public class Despawn : MonoBehaviour
{
    private float xlimit = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= xlimit || transform.position.y < -10f)
            Destroy(gameObject);
                
    }
}
