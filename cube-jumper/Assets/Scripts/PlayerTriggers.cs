using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTriggers : MonoBehaviour
{
    public WinLoseCondition winLoseCondition;
    public GameOverScreen gameOverScreen;
    public bool isDead;
    
    void Start()
    {
       
    }
    void Update()
    {
               
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("BaseFailGround"))
        {
            isDead = true;
            winLoseCondition.LoseLevel();
         
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            isDead = true;
            winLoseCondition.LoseLevel();
           
        }
    }
}
