using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    public GameManager GameManager;
    
    [Header ("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    
    [Header ("Hurt Sound")]
    [SerializeField] private AudioClip hurtSound;
    
    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    
    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth > 0)
        {
            //player hurt
            SoundManager.instance.PlaySound(hurtSound);
            return;
        }

        if (dead) return;
        
        // player dead, game over
        // deactivate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = false;

        GetComponent<PlayerController>().enabled = false;
    
        dead = true;
        SoundManager.instance.PlaySound(deathSound);

        GameManager.GameOver();
    }
    

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        
        foreach (Behaviour component in components)
            component.enabled = true;
    }
    
    // Update is called once per frame
    private void Update()
    {
        if(Keyboard.current[Key.F].wasPressedThisFrame)
        {
            TakeDamage(1);
        }
    }
}
