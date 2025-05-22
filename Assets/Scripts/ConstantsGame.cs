using UnityEngine;

public class ConstantsGame : MonoBehaviour
{

    public int numberOfWins;
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
    public int GetWins()
    {
        return numberOfWins;
    }
}
