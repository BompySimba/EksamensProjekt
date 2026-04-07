using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    public int scene = 1;
    public void GoToSceneTwo()
    {
     SceneManager.LoadScene(scene);  
    }
}
