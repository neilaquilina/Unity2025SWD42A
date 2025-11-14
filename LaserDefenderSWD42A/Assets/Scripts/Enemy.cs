using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 10;

    [SerializeField] float minimumTimeBetweenShots = 0.2f;
    [SerializeField] float maximumTimeBetweenShots = 3f;
    [SerializeField] float shotCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //read the damage dealer component from the colliding object
        DamageDealer dd = collision.gameObject.GetComponent<DamageDealer>();
        health -= dd.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject); //enemy dies
            dd.Hit(); //destroy the damage dealer object (laser)
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize shot counter with a random value between min and max time between shots
        shotCounter = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
