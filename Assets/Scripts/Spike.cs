using UnityEngine;

public class Spike : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.tag == "Player")
        {
            GameManager.instance.RestartLevel();
        }
        if (collisionInfo.tag == "Box")
        {
            Destroy(collisionInfo.gameObject);
            GameManager.instance.RespawnBox();
        }
    }
}
