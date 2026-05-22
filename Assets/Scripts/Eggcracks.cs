using UnityEngine;

public class Eggcracks : MonoBehaviour
{
    public class EnemyAttack : MonoBehaviour
    {
        public int damage;
        public Health playerHealth;
        public float attackCooldown;

        float _lastAttackTime;

        private void OnCollisionStay2D(Collision2D collision)
        {
            // Abort if we already attacked recently.
            if (Time.time - _lastAttackTime < attackCooldown) return;

            // CompareTag is cheaper than .tag ==
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHealth.TakeDamage(damage);

                // Remember that we recently attacked.
                _lastAttackTime = Time.time;
            }
        }
    }
}
