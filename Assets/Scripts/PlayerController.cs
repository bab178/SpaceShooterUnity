using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public GameObject playerExplosion;
    public AudioSource cannonAudio;
    public AudioSource deathAudio;

    public GameObject shot;
    public Transform shotSpawn;
    public Boundary boundary;
    public float speed;
    public float tilt;
    public float fireRate;

    private float nextFire;
    private static bool playerKilled;

    private GameController gc;

    void Start()
    {
        playerKilled = false;
        GameObject gameObj = GameObject.FindGameObjectWithTag("GameController");
        if (gameObj != null)
        {
            gc = gameObj.GetComponent<GameController>();
        }
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            cannonAudio.Play();
        }
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        float moveHorzontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorzontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            // take damage
            playerKilled = true;
            gc.GameOver();
        }

        if(playerKilled)
        {
            var explosion2 = Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            deathAudio.Play();
            // destroy player
            Destroy(explosion2, 3.0f); //waits 3.0f before destroying
        }
    }
}
