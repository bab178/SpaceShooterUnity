using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public GameObject explosion;
    public GameObject player_explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Asteroid")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(player_explosion, other.transform.position, other.transform.rotation);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
