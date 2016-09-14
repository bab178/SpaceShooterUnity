using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float MaxSpeed;

	void Start () {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * MaxSpeed;
	}
}
