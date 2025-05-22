using UnityEngine;
using UnityEngine.SceneManagement;

public class BombCheck : MonoBehaviour
{

    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(0f, 0f), 0f);

        foreach (var hit in hits)
        {
            if (hit.gameObject == player) // para no detectarse a sí mismo
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
