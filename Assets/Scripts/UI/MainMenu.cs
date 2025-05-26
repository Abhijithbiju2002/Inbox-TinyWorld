using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void OnPlay()
    {
        AudioManager.Instance.PlayClick();// WILL CHANGE IN FUTURE
        SceneManager.LoadScene("Game");
    }
    public void About()
    {
        AudioManager.Instance.PlayClick();// WILL CHANGE IN FUTURE
        SceneManager.LoadScene("About");
    }
    public void OnQuit()
    {
        AudioManager.Instance.PlayClick();// WILL CHANGE IN FUTURE
        Application.Quit();
    }
}
