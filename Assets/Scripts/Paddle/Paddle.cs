using UnityEngine;

[RequireComponent(typeof(MovementHandler))]
public class Paddle : MonoBehaviour {

    private MovementHandler movementHandler;
    private ShootingHandler shootingHandler;

    private void Awake() {
        movementHandler = GetComponent<MovementHandler>();
        shootingHandler = GetComponent<ShootingHandler>();
    }

    private void Update() {
        movementHandler.HandleMouseInput();
        shootingHandler?.Shoot();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<IPowerUp>()?.ApplyPowerUp(this.gameObject);
    }
}