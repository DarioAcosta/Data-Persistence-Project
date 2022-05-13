using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{


    public void goToMainMenu()
    {
        SceneManager.LoadScene("MM");
    }

    public void goToPlayGame()
    {
        SceneManager.LoadScene("main");
    }


}
