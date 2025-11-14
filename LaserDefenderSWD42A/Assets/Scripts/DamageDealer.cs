using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    // Returns the damage value of this DamageDealer
    public int GetDamage()
    {
        return damage;
    }

    // Destroys the game object this script is attached to
    public void Hit()
    {
        Destroy(gameObject);
    }
}
