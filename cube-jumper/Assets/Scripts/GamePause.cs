using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public SoundsManager pauseSound;
    private float originalTimeScale;

    // Start is called before the first frame update
    void Start()
    {
       pauseSound = GameObject.Find("SoundManager").GetComponent<SoundsManager>();
        Time.timeScale = 1;
       originalTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
            //need to lower the pitch of backgroundmusic
            pauseSound.SetBackgroundPitch(0.7f);
            StartCoroutine(PauseGameCoroutine());

        }
       else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
            //need to make the pitch to its normal value of backgroundmusic
            pauseSound.SetBackgroundPitch(pauseSound.normalBackgroundPitch);
            UnpauseGame();
        }
       
       
    }
       
    public void PauseGame()
    {

        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        

    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
       
    }

    IEnumerator PauseGameCoroutine()
    {
        pauseMenuUI.SetActive(true);
        float targetTimeScale = 0f; // Adjust this value to control the slowdown speed
        float duration = .5f; // Adjust this value to control the total duration of slowdown

        float elapsedTime = 0;

        while (Time.timeScale > targetTimeScale)
        {
            Time.timeScale = Mathf.Lerp(originalTimeScale, targetTimeScale, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = targetTimeScale;
       
    }

}
