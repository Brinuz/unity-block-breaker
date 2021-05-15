using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    [SerializeField]
    private List<PaddlePowerUp> powerUps;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float spawnChance = 0.1f;

    public void SpawnRandomPowerUp(Vector3 position) {
        var roll = Random.Range(0.0f, 1.0f);
        if (roll <= spawnChance) {
            Instantiate(powerUps[Random.Range(0, powerUps.Count)], position, Quaternion.identity);
        }
    }

    private void Awake() {
        FindObjectsOfType<Tile>()
            .ToList()
            .ForEach(t => t.OnGettingHit += () => SpawnRandomPowerUp(t.transform.position));
    }
}
