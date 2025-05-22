using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoviment : MonoBehaviour
{
    public float speed = 5f;
    public LayerMask wallLayer;
    public Vector2 boxSize = new Vector2(0.99f, 0.99f); // Tamaño del "hitbox" del jugador
    private Direction _movingDirection = Direction.None;
    private float _skinWidth = 0.002f; // Pequeña distancia para evitar penetrar en la pared

    void Update()
    {
        if (_movingDirection != Direction.None)
        {
            Vector3 moveDir = GetDirectionVector(_movingDirection);
            float moveDistance = speed * Time.deltaTime;

            // Realiza un BoxCast para detectar colisiones
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, moveDir, moveDistance + _skinWidth, wallLayer);

            if (hit.collider != null)
            {
                // Moverse solo hasta el punto justo antes de colisionar
                float distanceToWall = hit.distance - _skinWidth;
                if (distanceToWall > 0)
                    transform.position += moveDir * distanceToWall;
                
                // Detener el movimiento al chocar
                _movingDirection = Direction.None;
            }
            else
            {
                // No hay colisión, moverse normalmente
                transform.position += moveDir * moveDistance;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                _movingDirection = Input.GetAxisRaw("Horizontal") > 0 ? Direction.Right : Direction.Left;
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                _movingDirection = Input.GetAxisRaw("Vertical") > 0 ? Direction.Up : Direction.Down;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    Vector3 GetDirectionVector(Direction dir)
    {
        return dir switch
        {
            Direction.Left => Vector3.left,
            Direction.Right => Vector3.right,
            Direction.Up => Vector3.up,
            Direction.Down => Vector3.down,
            _ => Vector3.zero
        };
    }

    enum Direction
    {
        Up, Down, Left, Right, None
    }
}
