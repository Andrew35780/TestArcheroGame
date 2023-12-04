using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 15f;

    private void Start() => rb = GetComponent<Rigidbody>();

    private void Update() => rb.velocity = transform.TransformDirection(Vector3.forward * speed);

    private void OnCollisionEnter(Collision collision) => gameObject.SetActive(false);
}