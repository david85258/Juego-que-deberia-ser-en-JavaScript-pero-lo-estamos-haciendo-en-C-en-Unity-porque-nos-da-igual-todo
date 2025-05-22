using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    public GameObject player;
    private int Count = 1;
    
    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(0f, 0f), 0f);

        foreach (var hit in hits)
        {
            if (hit.gameObject == player && Count == 1) // para no detectarse a sí mismo
            {
                
                if (!ConstantsGame.Instance.CompWins())
                {
                    player.GetComponent<PlayerMoviment>().enabled = false;
                    Count--;
                }
                else
                {
                    string name = SceneManager.GetActiveScene().name;
                    string[] split = name.Split(" ");
                    if (split.Length == 2 && split[0].Equals("LvL"))
                    {
                        try
                        {
                            int result = Int32.Parse(split[1]);
                            result += 1;
                            SceneLoader.LoadScene("LvL "+result);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Unable to parse '{split[1]}'");
                        }
                    }
                }
                
            }
        }
    }
}
