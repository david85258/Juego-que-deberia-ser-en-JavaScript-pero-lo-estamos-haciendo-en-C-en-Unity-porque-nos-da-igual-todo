using UnityEngine;

public class ConstantsGame : MonoBehaviour
{

    public int numberOfWins = 0;
    private int activatedWins = 0;
    public static ConstantsGame Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Elimina duplicados si ya existe uno
            return;
        }

        Instance = this; 
    }

    // Tu lógica aquí
    public bool CompWins()
    {
        activatedWins++;
        return activatedWins == numberOfWins;
    }
}
