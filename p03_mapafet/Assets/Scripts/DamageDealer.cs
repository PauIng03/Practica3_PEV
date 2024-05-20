using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage = 10;
    private bool hasDealtDamage = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colissió detectada");

        if (!hasDealtDamage)
        {
            var healthSystem = collision.collider.GetComponent<HealthSystem>();
            Debug.Log("encara no mal");
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damage);
                hasDealtDamage = true;
                GetComponent<Collider>().enabled = false;
                Debug.Log("S'ha fet mal");
            }
        }
    }
}
