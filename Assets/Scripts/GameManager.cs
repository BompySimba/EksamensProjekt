using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject boxPrefab;
    private GameObject currentBox;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnBox();
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RespawnBox()
    {
        if (currentBox != null)
        {
            Destroy(currentBox);
        }
        Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
    }
    public void BoxDestroyed()
    {
        currentBox = null;
        RespawnBox();
    }
}
