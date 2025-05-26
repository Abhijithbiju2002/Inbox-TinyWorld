using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    bool isGameOver = false;

    public void CheckGmeOver(int morale, int money)
    {
        if (isGameOver) return;

        if (morale <= 0 || money <= 0)
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; //pause the gamee
        }
    }
    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayClick();//JUST FOR NOW...WILL CHNAGE IN FUTURE
        SceneManager.LoadScene("MainMenu");

    }
    public void OnQuit()
    {
        AudioManager.Instance.PlayClick();// WILL CHANGE IN FUTURE
        Application.Quit();
    }

}
