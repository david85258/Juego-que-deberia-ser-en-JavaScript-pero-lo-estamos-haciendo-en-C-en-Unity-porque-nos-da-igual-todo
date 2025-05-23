using UnityEngine;

public class ConstantsGame : MonoBehaviour
{
    public static ConstantsGame Instance { get; private set; }

    public int numberOfWinsAndPlayers = 0;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Elimina duplicados si ya existe uno
            return;
        }

        Instance = this; 
    }
    
    // Wins
    private int activatedWins = 0;

    public bool CompWins()
    {
        activatedWins++;
        return activatedWins == numberOfWinsAndPlayers;
    }
    
}
