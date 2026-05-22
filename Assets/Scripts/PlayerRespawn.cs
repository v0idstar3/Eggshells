using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;//sounds that will play on a new checkpoint
    private Transform currentCheckpoint; //store last checkpoint here
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }
    
    public void Respawn()
    {
        transform.position = currentCheckpoint.position; //move player to checkpoint position
        playerHealth.Respawn();// restore player health and reset animation
        
        //Move camera back to checkpoint room
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
            {
            currentCheckpoint = collision.transform; //store checkpoint activated as current checkpoint
            SoundManager.instance.PlaySound(checkpointSound);
            collision.GetComponent<Collider2D>().enabled = false;
            }
    }
}

