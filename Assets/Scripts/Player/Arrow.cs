using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 25f;

    private void Start() => rb = GetComponent<Rigidbody>();

    private void Update() => rb.velocity = transform.TransformDirection(Vector3.forward * speed);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "EnemyBullet")
            gameObject.SetActive(false);
    }
}
