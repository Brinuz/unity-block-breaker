using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour {

    private int score = 0;

    private void Awake() {
        FindObjectsOfType<Tile>()
            .ToList()
            .ForEach(t => t.OnGettingHit += () => score += 1);
    }

    private void Start() {
        Cursor.visible = false;
    }
}
