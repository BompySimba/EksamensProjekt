using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject boxPrefab;
    public Transform spawnPoint;

    private GameObject currentBox;
    public static GameManager instance;
    public bool playerIsDead = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    void Start()
    {
        currentBox = GameObject.FindWithTag("Box");
        playerIsDead = false;
    }

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
        playerIsDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RespawnBox()
    {
        if (currentBox != null)
        {
            Destroy(currentBox);
            currentBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void BoxDestroyed()
    {
        currentBox = null;
        RespawnBox();
    }
    public void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1.0f;
    }
}