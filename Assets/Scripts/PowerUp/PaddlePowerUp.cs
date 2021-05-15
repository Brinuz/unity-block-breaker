using System;
using UnityEngine;

[Serializable]
public class PaddlePowerUp : MonoBehaviour, IPowerUp {

    [SerializeField]
    private Paddle poweredUpPaddle;

    [SerializeField]
    private int powerUpTimeout;

    public void ApplyPowerUp(GameObject source) {
        Destroy(this.gameObject);
        FindObjectOfType<PaddleSpawner>().Spawn(poweredUpPaddle, source.transform.position, powerUpTimeout);
    }

}
