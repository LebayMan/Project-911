using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
