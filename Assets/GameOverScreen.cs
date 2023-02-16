using TMPro;

public class GameOverScreen : UIScreen
{
    public TextMeshProUGUI killedText;

    public void GameOver(int killed)
    {
        Trigger();
        killedText.text = $"You killed: {killed}/20 slimes";
    }
}
