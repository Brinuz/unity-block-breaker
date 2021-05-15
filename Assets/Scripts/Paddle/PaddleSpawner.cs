using System;
using UnityEngine;

public class PaddleSpawner : MonoBehaviour {

    [SerializeField]
    private Paddle basePaddle;

    private Paddle spawnedPaddle;
    private long paddleLifeSpan = -1;

    public Paddle Spawn(Paddle paddle, Vector3 position, int timespan) {
        spawnedPaddle = this.Spawn(paddle, position);
        paddleLifeSpan = DateTimeOffset.Now.AddSeconds(timespan).ToUnixTimeSeconds();
        return spawnedPaddle;
    }

    public Paddle Spawn(Paddle paddle, Vector3 position) {
        Destroy(spawnedPaddle.gameObject);
        spawnedPaddle = Instantiate(paddle, position, Quaternion.identity);
        paddleLifeSpan = -1;
        return spawnedPaddle;
    }

    private void Awake() {
        var existingPaddle = FindObjectOfType<Paddle>();
        if (existingPaddle) {
            spawnedPaddle = existingPaddle;
        } else {
            Debug.LogError("Missing paddle in Game Scene");
        }
    }

    private void Update() {
        HandleExpired();
    }

    private void HandleExpired() {
        var now_epoch = DateTimeOffset.Now.ToUnixTimeSeconds();
        if (paddleLifeSpan > 0 && now_epoch >= paddleLifeSpan) {
            this.Spawn(basePaddle, spawnedPaddle.gameObject.transform.position);
        }
    }
}
