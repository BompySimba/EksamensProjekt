using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    public int scene = 1;
    public void GoToMenu()
    {
     SceneManager.LoadScene(scene);  
    }
}
