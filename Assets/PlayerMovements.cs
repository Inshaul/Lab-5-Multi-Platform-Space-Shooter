using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed = 5f;
    public float maxPositionX = 5f;
    public float maxPositionZ = 20f;
    
    void Start()
    {
        if(rb == null){
            rb = GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        Vector2 input = InputManager.instance.moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y) * speed;
        rb.velocity = movement;
        
        // Clamp the position to keep the player within bounds
        float clampedX = Mathf.Clamp(rb.position.x, -maxPositionX, maxPositionX);
        float clampedZ = Mathf.Clamp(rb.position.z, 0, 10f);
        rb.position = new Vector3(clampedX, rb.position.y, clampedZ);

        // Add tilt effect
        float rotationZ = -input.x * 5f;
        rb.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}