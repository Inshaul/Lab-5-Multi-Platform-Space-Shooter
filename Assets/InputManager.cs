using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Step 1: Singleton setup
    public static InputManager instance;

    // Step 3: Editor-accessible Input Action Asset
    public InputActionAsset controls;

    // Step 4: Publicly accessible Input Action for Move
    public InputAction moveAction;
    public InputAction fireAction;

    void Awake()
    {
        // Implementing singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Step 5: Assign Move action from Input Action Asset
        moveAction = controls.FindAction("Move");
        moveAction.Enable();

        fireAction = controls.FindAction("Fire");
        fireAction.Enable();
    }
}