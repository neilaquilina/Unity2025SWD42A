using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int health = 10;

    [SerializeField] float minimumTimeBetweenShots = 0.2f;
    [SerializeField] float maximumTimeBetweenShots = 3f;
    [SerializeField] float shotCounter;

    [SerializeField] GameObject laserPrefab;

    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField][Range(0, 1)] float enemyDeathSoundVolume = 0.7f;

    [SerializeField] AudioClip enemyShootSound;
    [SerializeField][Range(0, 1)] float enemyShootSoundVolume = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //read the damage dealer component from the colliding object
        DamageDealer dd = collision.gameObject.GetComponent<DamageDealer>();
        health -= dd.GetDamage();
             

        dd.Hit(); //destroy the damage dealer object (laser)

        if (health <= 0)
        {
            //play death sound
            AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);
            
            Destroy(gameObject); //enemy dies
            
        }

    }

    void CountdownAndShoot()
    {
        //count down the shot counter each frame
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            //shoot
            EnemyFire();
            //reset the shot counter with a new random value
            shotCounter = Random.Range(minimumTimeBetweenShots, maximumTimeBetweenShots);
        }
    }

    void EnemyFire()
    {
        // Instantiate the laser prefab at the enemy's position with no rotation
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().linearVelocityY = -5f;

        //play shooting sound
        AudioSource.PlayClipAtPoint(enemyShootSound, Camera.main.transform.position, enemyShootSoundVolume);

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
        CountdownAndShoot();
    }
}
