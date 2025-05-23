using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class BombCheck : MonoBehaviour
{

    public GameObject[] players;

    public void Awake()
    {
        GetComponent<SpriteRenderer>().material.SetFloat("_Hue", Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(0f, 0f), 0f);

        foreach (var hit in hits)
        {
            foreach (var player in players)
            {
                if (hit.gameObject == player) // para no detectarse a sí mismo
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
