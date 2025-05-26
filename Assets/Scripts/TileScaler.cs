using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class TileScaler : MonoBehaviour
{
    private Vector3 _lastKnownScale;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider2D;
    
    void OnEnable() // O Awake
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _lastKnownScale = transform.localScale; // Guardar la escala inicial
        ApplyScaling();
    }

#if UNITY_EDITOR
    void Update() // O OnValidate para cambios en el inspector
    {
        if (!Application.isPlaying)
        {
            if (transform.localScale != _lastKnownScale && transform.localScale != Vector3.one)
            {
                // El usuario cambió la escala, vamos a aplicarla
                _lastKnownScale = transform.localScale;
                ApplyScaling();
            }
            // Si la escala es 1 y lastKnownScale no es 1, significa que ya la aplicamos
            // y el usuario no la ha vuelto a tocar para que sea != 1.
        }
    }
#endif

    void ApplyScaling()
    {
        if (_spriteRenderer == null || _boxCollider2D == null) return;

        Vector3 targetScale = transform.localScale; // Usar la escala actual como fuente

        // Asegurarse que el DrawMode es Tiled
        if (_spriteRenderer.drawMode != SpriteDrawMode.Tiled)
        {
            _spriteRenderer.drawMode = SpriteDrawMode.Tiled;
            Debug.LogWarning($"TileScaler: SpriteDrawMode en {gameObject.name} cambiado a Tiled.");
        }

        _spriteRenderer.size = new Vector2(targetScale.x, targetScale.y);
        _boxCollider2D.size = new Vector2(targetScale.x, targetScale.y);
        // Asumimos que el offset del collider es (0,0) y el pivote del sprite está centrado.

        // MUY IMPORTANTE: Restablecer la escala del transform a (1,1,1) para evitar el estiramiento.
        transform.localScale = Vector3.one;
        _lastKnownScale = Vector3.one; // Actualizar lastKnownScale para reflejar el reseteo

#if UNITY_EDITOR
        if (!Application.isPlaying)
        {
            UnityEditor.EditorUtility.SetDirty(this); // Marcar el script como modificado
            UnityEditor.EditorUtility.SetDirty(_spriteRenderer);
            UnityEditor.EditorUtility.SetDirty(_boxCollider2D);
        }
#endif
        // Debug.Log($"Scaling applied. SR Size: {_spriteRenderer.size}, BC Size: {_boxCollider2D.size}, Transform Scale: {transform.localScale}");
    }
}