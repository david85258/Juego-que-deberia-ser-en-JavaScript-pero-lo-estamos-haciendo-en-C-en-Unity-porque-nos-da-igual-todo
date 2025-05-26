using UnityEngine;

public class SpriteColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Tooltip("Velocidad a la que cambia el matiz (0 a 1 por segundo). Un valor de 0.1 significa que tardará 10 segundos en completar un ciclo de color.")]
    public float hueChangeSpeed = 0.1f;

    [Tooltip("Saturación del color (0=gris, 1=color puro).")]
    [Range(0f, 1f)]
    public float saturation = 1.0f;

    [Tooltip("Brillo/Valor del color (0=negro, 1=color brillante).")]
    [Range(0f, 1f)]
    public float value = 1.0f;

    private float currentHue = 0.0f;
    private float initialAlpha; // Para mantener el alfa original del sprite

    void Start()
    {
        // Obtener el componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteColorChanger: No se encontró el componente SpriteRenderer en este GameObject.");
            enabled = false; // Desactivar el script si no hay SpriteRenderer
            return;
        }

        // Guardar el alfa inicial del sprite
        initialAlpha = spriteRenderer.color.a;

        // Opcional: Si quieres empezar con un color aleatorio del ciclo
        currentHue = Random.Range(0f, 1f);
    }

    void Update()
    {
        if (spriteRenderer == null) return;

        // Incrementar el matiz (Hue)
        currentHue += hueChangeSpeed * Time.deltaTime;

        // Asegurarse de que el matiz se mantenga en el rango [0, 1] y cicle
        if (currentHue > 1.0f)
        {
            currentHue -= 1.0f;
        }
        // Alternativamente, podrías usar el operador módulo:
        // currentHue = currentHue % 1.0f;

        // Convertir de HSV a RGB
        // Color.HSVToRGB(hue, saturation, value) devuelve un color con alfa = 1.0f
        Color newColor = Color.HSVToRGB(currentHue, saturation, value);

        // Aplicar el alfa original del sprite al nuevo color
        newColor.a = initialAlpha;
        // Si quieres que el alfa sea siempre 1 (completamente opaco), puedes usar:
        // newColor.a = 1f;

        // Aplicar el nuevo color al SpriteRenderer
        spriteRenderer.color = newColor;
    }
}