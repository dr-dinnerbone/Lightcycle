using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 10f;
    [SerializeField] private TrailRenderer trail;
    private Vector2 dirVector;
    private Direction _dir;
    public Direction dir
    {
        get => _dir;
        set
        {
            switch (value)
            {
                case Direction.Up:
                    dirVector = Vector2.up;
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case Direction.Down:
                    dirVector = Vector2.down;
                    transform.eulerAngles = new Vector3(0, 0, 270);
                    break;
                case Direction.Left:
                    dirVector = Vector2.left;
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
                case Direction.Right:
                    dirVector = Vector2.right;
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
            }
            trail.AddPosition(transform.position);
            _dir = value;
        }
    }
    private void Start()
    {
        if (trail is null)
            trail = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        transform.Translate(dirVector * baseSpeed * Time.deltaTime, Space.World);
    }
    /// <summary>
    /// Ensures lightcycle cannot turn 180 degrees and collide with itself
    /// </summary>
    /// <param name="newDir">Intended direction to turn towards</param>
    public void Turn(Direction newDir)
    {
        if (dir == Direction.Up && newDir == Direction.Down || dir == Direction.Down && newDir == Direction.Up) return;
        if (dir == Direction.Left && newDir == Direction.Right || dir == Direction.Right && newDir == Direction.Left) return;
        dir = newDir;
    }
}