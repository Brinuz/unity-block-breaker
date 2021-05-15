using UnityEngine;

public class Ball : MonoBehaviour, IDamageDealer {

    [SerializeField]
    private Paddle paddle;

    [SerializeField]
    [Range(10f, 20f)]
    private float ballSpeed;

    [SerializeField]
    private int damage = 1;

    private bool launched = false;
    private Vector3 paddleToBallDistance;
    private AudioSource audioSource;

    public int GetDamage() {
        return damage;
    }

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        paddleToBallDistance = gameObject.transform.position - paddle.transform.position;
    }

    private void Update() {
        if (!launched) {
            PreStartBehaviour();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        audioSource.Play();
    }

    private void PreStartBehaviour() {
        // Keep ball attached to the paddle on paddle movement
        gameObject.transform.position = paddle.transform.position + paddleToBallDistance;

        if (Input.GetMouseButtonUp(0)) {
            launched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, ballSpeed);
        }
    }
}
