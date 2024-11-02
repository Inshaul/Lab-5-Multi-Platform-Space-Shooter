using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    public float speed = 10f;

    void FixedUpdate()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }

        if(other.CompareTag("Asteroid")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}