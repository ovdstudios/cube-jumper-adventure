using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public WinLoseCondition winLoseCondition;
   

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
             winLoseCondition.LoseLevel();
             winLoseCondition.ReloadManager(0);
           }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            winLoseCondition.LoseLevel();
            winLoseCondition.ReloadManager(0);
        }
    }
}
