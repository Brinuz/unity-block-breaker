using System;
using UnityEngine;

public class Tile : MonoBehaviour, IDamageReceiver {

    [SerializeField]
    private Sprite[] destructionSprites;

    private SpriteRenderer spriteRenderer;
    private int hitsToDestroy = 1;
    private int currentHits = 0;

    public Action OnGettingHit;

    public int GetHealth() {
        return hitsToDestroy - currentHits;
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        hitsToDestroy = destructionSprites.Length + 1;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        HandleHit(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        HandleHit(other.gameObject);
    }

    private void HandleHit(GameObject collisionObject) {
        var damageDealer = collisionObject.GetComponent<IDamageDealer>();
        if (damageDealer != null) {
            OnGettingHit?.Invoke();
            HandleDamage(damageDealer);
        }
    }

    private void HandleDamage(IDamageDealer damageDealer) {
        currentHits += damageDealer.GetDamage();
        if (currentHits >= hitsToDestroy) {
            Destroy(this.gameObject);
            return;
        }
        spriteRenderer.sprite = destructionSprites[currentHits - 1];
    }
}