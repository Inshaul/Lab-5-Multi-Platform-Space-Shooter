using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    public float speed = 10f;

    void FixedUpdate()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}