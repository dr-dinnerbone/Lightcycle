using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 10f;
    private Vector2 dir = Vector2.down;
    private void Update()
    {
        transform.Translate(dir * baseSpeed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f); // converts Vector2 dir to degrees
    }
    /// <summary>
    /// Ensures lightcycle cannot turn 180 degrees and collide with itself
    /// </summary>
    /// <param name="newDir">Intended direction to turn towards</param>
    public void Turn(Vector2 newDir)
    {
        if (dir == Vector2.down && newDir == Vector2.up || dir == Vector2.up && newDir == Vector2.down) return;
        if (dir == Vector2.left && newDir == Vector2.right || dir == Vector2.right && newDir == Vector2.left) return;
        dir = newDir;
    }
}