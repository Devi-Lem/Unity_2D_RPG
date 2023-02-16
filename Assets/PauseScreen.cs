using UnityEngine;

public class PauseScreen : UIScreen
{
    public void ResumeButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
