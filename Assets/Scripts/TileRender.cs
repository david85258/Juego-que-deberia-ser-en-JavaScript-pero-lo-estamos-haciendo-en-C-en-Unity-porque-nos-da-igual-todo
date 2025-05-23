using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TileRender : MonoBehaviour
{
    public Vector2 tileSize = new Vector2(10f, 10f); // cada 10x10 unidades = 1 tile

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.drawMode = SpriteDrawMode.Tiled;

        UpdateTiling();
    }

    void Update()
    {
        //UpdateTiling();
    }

    void UpdateTiling()
    {
        Vector3 lossyScale = transform.lossyScale;
        float width = lossyScale.x / tileSize.x;
        float height = lossyScale.y / tileSize.y;

        sr.size = new Vector2(width, height);
    }
}
