using System;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private float speed;
    private float horizontalDrift;

    public Action onDestroyed;


    private void Awake() {
        if(rb == null){
            rb = GetComponent<Rigidbody>();
        }
    }
    void Start()
    {
        // Set random angular velocity for rotation
        rb.angularVelocity = UnityEngine.Random.insideUnitSphere * 2.0f; 


        // Randomize the asteroid's forward speed between 0.5 and 1.5
        speed = UnityEngine.Random.Range(1f, 5f);

        // Randomize slight horizontal drift for variation
        horizontalDrift = UnityEngine.Random.Range(-0.2f, 0.2f);

        // Set the initial velocity
        rb.velocity = new Vector3(horizontalDrift, 0, -speed);
    }

    private void FixedUpdate() {
        if(rb.position.z <= -2f){
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Notify the spawner that this asteroid has been destroyed
        if (onDestroyed != null)
        {
            onDestroyed.Invoke();
        }
    }
}