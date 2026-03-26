using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.tag == "Player")
        {
            gameManager.RestartLevel();
        }
        if (collisionInfo.tag == "Box")
        {
            Destroy(collisionInfo.gameObject);
            gameManager.RespawnBox();
        }
    }
}
