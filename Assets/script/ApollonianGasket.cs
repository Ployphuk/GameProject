using UnityEngine;

public class ApollonianGasket : MonoBehaviour
{
    public float radius = 1.0f;
    public int iterations = 3;
    public Material material;

    private void Start()
    {
        CreateGasket(transform.position, radius, iterations);
    }

    private void CreateGasket(Vector2 center, float r, int n)
    {
        if (n == 0)
            return;

        // Create a new circle GameObject
        GameObject circle = new GameObject("Circle");
        circle.transform.parent = transform;
        circle.transform.position = center;

        // Add a Circle Collider 2D component
        CircleCollider2D collider = circle.AddComponent<CircleCollider2D>();
        collider.radius = r;

        // Add a Sprite Renderer component
        SpriteRenderer renderer = circle.AddComponent<SpriteRenderer>();
        renderer.sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 1, 1), Vector2.one * 0.5f);
        renderer.material = material;
        renderer.color = Random.ColorHSV();

        // Recursively create smaller circles
        float r1 = r / (2 + Mathf.Sqrt(3));
        float r2 = r1 * Mathf.Sqrt(3);
        CreateGasket(center + new Vector2(r, 0), r1, n - 1);
        CreateGasket(center + new Vector2(-r / 2, r2), r1, n - 1);
        CreateGasket(center + new Vector2(-r / 2, -r2), r1, n - 1);
    }
}
