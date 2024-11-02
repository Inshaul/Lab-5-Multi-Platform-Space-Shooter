using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed = 5f;
    public float maxPositionX = 5f;
    public float maxPositionZ = 20f;

    public GameObject boltPrefab;
    public Transform boltSpawnPoint;
    public float fireRate = 0.05f;
    private float nextFireTime = 0f;
    
    void Start()
    {
        if(rb == null){
            rb = GetComponent<Rigidbody>();
        }
    }


    private void Update() {
        HandleShooting();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleShooting(){
    // Check if Fire action is triggered and if enough time has passed since last shot
        if (InputManager.instance.fireAction.triggered && Time.time >= nextFireTime)
        {
            // Instantiate the bolt at the spawn position and rotation
            Instantiate(boltPrefab, boltSpawnPoint);
            
            // Set the next allowable fire time based on the fire rate
            nextFireTime = Time.time + fireRate;
        }
    }

    private void HandleMovement(){

        Vector2 input = InputManager.instance.moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y) * speed;
        rb.velocity = movement;

        // Clamp the position to keep the player within bounds
        float clampedX = Mathf.Clamp(rb.position.x, -maxPositionX, maxPositionX);
        float clampedZ = Mathf.Clamp(rb.position.z, 0, 10f);
        rb.position = new Vector3(clampedX, rb.position.y, clampedZ);

        // Add tilt effect
        float rotationZ = -input.x * 10f;
        rb.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

}