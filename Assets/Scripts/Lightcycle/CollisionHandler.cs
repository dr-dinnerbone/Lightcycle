using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float range = 5f;
    [SerializeField] private float offset = 5f;
    private void Update()
    {
        if (movementController is null) return;

        Vector2 dir = Vector2.zero;
        switch (movementController.dir)
        {
            case Direction.Up:
                dir = Vector2.up;
                break;
            case Direction.Down:
                dir = Vector2.down;
                break;
            case Direction.Left:
                dir = Vector2.left;
                break;
            case Direction.Right:
                dir = Vector2.right;
                break;
        }

        Vector2 origin = (Vector2)transform.position + (dir * offset);
        RaycastHit2D hit = Physics2D.Raycast(origin, dir, range, targetLayer);
        if (hit.collider is not null)
        {
            Debug.Log("asdf");
        }
    }
}
