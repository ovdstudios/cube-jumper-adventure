using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    
    public GameObject gameOverUI;
    [SerializeField] StopMusic stopmusic;
    [SerializeField] PlayFailMusic playfailmusic;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        playfailmusic.FailSound();
        gameOverUI.gameObject.SetActive(true);      
        stopmusic.StopMusicOnFail();
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
