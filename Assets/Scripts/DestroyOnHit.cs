using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource audioSourceAsteroid;

    private GameController gc;

    void Start()
    {
       GameObject gameObj = GameObject.FindGameObjectWithTag("GameController");
        if(gameObj != null)
        {
            gc = gameObj.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary" && other.tag != "Asteroid")
        {
            var explosion1 = Instantiate(explosion, transform.position, transform.rotation);
            audioSourceAsteroid.Play();
            Destroy(explosion1, 3.0f); //waits 3.0f before destroying

            if(other.tag != "Player")
            {
                // Destroy shots, other
                Destroy(other.gameObject);
                gc.AddScore(1);
            }

            // Destroy asteroid
            Destroy(gameObject);
        }
    }
}
