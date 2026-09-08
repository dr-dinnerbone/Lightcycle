using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    private void Start()
    {
        movementController = GetComponent<MovementController>();
    }
    public void OnMove(InputAction.CallbackContext c)
    {
        if (movementController is null) return;
        if (c.performed)
        {
            Vector2 inputDir = c.ReadValue<Vector2>();
            if (inputDir.x != 0 && inputDir.y != 0) return;
            switch ((inputDir.x, inputDir.y))
            {
                case (1f, 0f):
                    movementController.Turn(Direction.Right);
                    break;
                case (-1f, 0f):
                    movementController.Turn(Direction.Left);
                    break;
                case (0f, 1f):
                    movementController.Turn(Direction.Up);
                    break;
                case (0f, -1f):
                    movementController.Turn(Direction.Down);
                    break;

            }
        }
    }
}
