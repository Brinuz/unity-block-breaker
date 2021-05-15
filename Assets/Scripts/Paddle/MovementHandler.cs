using UnityEngine;

public class MovementHandler : MonoBehaviour {
    public void HandleMouseInput() {
        var mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        this.gameObject.transform.position = new Vector2(Mathf.Clamp(mousePosX, -14f, 14f), this.gameObject.transform.position.y);
    }
}
