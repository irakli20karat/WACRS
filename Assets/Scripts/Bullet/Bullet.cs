using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 805f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);

        // destroy bullet if out of map
        if (transform.position.y < -500)
        {
            Destroy(gameObject);
        }
    }
}
