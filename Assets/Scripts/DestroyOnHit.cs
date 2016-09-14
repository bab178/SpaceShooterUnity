using UnityEngine;

public class DestroyOnHit : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag != "Asteroid")
        //{
        //    Destroy(other.gameObject);
        //    Destroy(gameObject);
        //}
    }
}
