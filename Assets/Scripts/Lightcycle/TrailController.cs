using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private float trailWidth = 5f;
    private BoxCollider2D currentCollider;
    private Vector3 currentColliderOrigin;
    private Direction lastDir;
    private static Transform trailHolder;
    private void Start()
    {
        if (trailHolder is null)
        {
            GameObject holder = new GameObject("Trails");
            trailHolder = holder.transform;
        }

        lastDir = movementController.dir;
        StartNewTrailSegment();
    }
    private void Update()
    {

        if (movementController.dir != lastDir)
            StartNewTrailSegment();

        if (currentCollider is null) return;

        float distance = Vector3.Distance(currentColliderOrigin, transform.position);
        currentCollider.size = new Vector2(distance, trailWidth);
        currentCollider.offset = new Vector2(-distance / 2f, 0f);
    }
    private void StartNewTrailSegment()
    {
        lastDir = movementController.dir;
        currentColliderOrigin = transform.position;

        GameObject segment = new GameObject("Trail Segment");
        segment.layer = LayerMask.NameToLayer("Trail");
        segment.transform.SetParent(trailHolder);
        segment.transform.position = currentColliderOrigin;

        float dir;
        switch (movementController.dir) // directions are flipped as movementController.dir is the direction the player is facing and trails should be created in the opposite direction
        {
            case Direction.Up:
                dir = 270f;
                break;
            case Direction.Down:
                dir = 90f;
                break;
            case Direction.Left:
                dir = 0f;
                break;
            case Direction.Right:
                dir = 90f;
                break;
            default:
                dir = 90f;
                break;
        }
        segment.transform.rotation = Quaternion.Euler(0, 0, dir);
        currentCollider = segment.AddComponent<BoxCollider2D>();
        currentCollider.isTrigger = true;
    }
}
