using UnityEngine;

public class LaserBullet : MonoBehaviour, IDamageDealer {

    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    private int damage = 1;

    private Rigidbody2D rBody;

    public int GetDamage() {
        return damage;
    }

    private void Awake() {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        rBody.velocity = new Vector2(0f, bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<IDamageReceiver>() != null) {
            Destroy(this.gameObject);
        }
    }
}
