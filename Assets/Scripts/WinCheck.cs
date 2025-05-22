using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    public GameObject player;
    public SceneAsset scene;
    
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(0f, 0f), 0f);

        foreach (var hit in hits)
        {
            if (hit.gameObject == player) // para no detectarse a sí mismo
            {
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
