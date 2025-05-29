using UnityEngine;

public class SpellDamage : MonoBehaviour
{
    
    public float damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter(Collision collision)
    {
        Health? health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        
    }
}
