using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomizeColor : MonoBehaviour
{
    public void Awake()
    {
        GetComponent<SpriteRenderer>().material.SetFloat("_Hue", Random.Range(0f, 1f));
    }
}
