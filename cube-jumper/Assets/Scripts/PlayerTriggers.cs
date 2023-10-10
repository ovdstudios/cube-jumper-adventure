using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerTriggers : MonoBehaviour
{
    public WinLoseCondition winLoseCondition;
    public GameOverScreen gameOverScreen;
    private PlayerPhysicsController physicsController;
    void Start()
    {
        physicsController =GetComponent<PlayerPhysicsController>();
    }
    void Update()
    {
               
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("BaseFailGround"))
        {
            winLoseCondition.LoseLevel();
            physicsController.isDead = true;
           }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            winLoseCondition.LoseLevel();
            physicsController.isDead = true;
        }
    }
}
