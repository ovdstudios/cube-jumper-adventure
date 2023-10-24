using UnityEngine;

public class PressSpaceToStart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spaceToStartUI;
    
    public bool isPaused;    

    private void Awake()
    {
        spaceToStartUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        SpaceToStart();

    }

    public void SpaceToStart()
    {
        if (isPaused && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            isPaused = false;
            spaceToStartUI.SetActive(false);
        }
        else
        {
            return;
        }

    }

}
