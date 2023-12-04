using UnityEngine;

public class CollisionFixer : MonoBehaviour
{
    private Collider enemyCollider;

    private void Start() => enemyCollider = GetComponent<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "DamageItem")
            Physics.IgnoreCollision(collision.collider, enemyCollider);
    }
}
