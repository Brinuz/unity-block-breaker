using UnityEngine;

public class DestroyTrespasser : MonoBehaviour {

    // Not pretty, but is enough for now
    private void OnTriggerEnter2D(Collider2D other) => Destroy(other.gameObject);
}
