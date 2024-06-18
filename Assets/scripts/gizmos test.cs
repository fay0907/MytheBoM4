using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Ensures that the GameObject has a Collider2D component
public class Gizmostest : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Collider2D collider = GetComponent<Collider2D>();

        if (collider != null)
        {
            if (collider is BoxCollider2D)
            {
                DrawBoxCollider2DGizmo((BoxCollider2D)collider);
            }
            else if (collider is CircleCollider2D)
            {
                DrawCircleCollider2DGizmo((CircleCollider2D)collider);
            }
            // Add support for other 2D collider types as needed (PolygonCollider2D, etc.)
        }
    }

    private void DrawBoxCollider2DGizmo(BoxCollider2D boxCollider)
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawWireCube(boxCollider.offset, boxCollider.size);
    }

    private void DrawCircleCollider2DGizmo(CircleCollider2D circleCollider)
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawWireSphere(circleCollider.offset, circleCollider.radius);
    }

    // Optionally, you can also override OnDrawGizmosSelected() for selected GameObjects
    // to show more detailed Gizmos if needed.
}