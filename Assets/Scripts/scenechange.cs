using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    public void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);  
    }
}
