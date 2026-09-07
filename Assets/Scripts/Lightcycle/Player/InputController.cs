using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    private void Start()
    {
        movementController = GetComponent<MovementController>();
    }
    public void OnMove(InputAction.CallbackContext c)
    {
        if (c.performed)
        {
            Vector2 inputDir = c.ReadValue<Vector2>();
            if (inputDir.x != 0 && inputDir.y != 0) return;
            if (movementController is not null) movementController.Turn(inputDir);
        }
    }
}
