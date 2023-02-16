using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScreen : MonoBehaviour
{
    public void Trigger()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}