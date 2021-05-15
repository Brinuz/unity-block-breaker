using UnityEngine;

public class ShootingHandler : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Vector2 offset = new Vector2(0f, 0f);

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot() {
        var bullet2spawnLocation = this.gameObject.transform.position + new Vector3(offset.x, offset.y, 1f);
        var bullet1spawnLocation = this.gameObject.transform.position + new Vector3(-offset.x, offset.y, 1f);

        if (Input.GetKeyDown(KeyCode.Space)) {
            audioSource?.Play();
            Instantiate(bulletPrefab, bullet1spawnLocation, Quaternion.identity);
            Instantiate(bulletPrefab, bullet2spawnLocation, Quaternion.identity);
        }
    }
}
