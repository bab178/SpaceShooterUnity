using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardWaves;
    public float startWavesDelay;
    public float waveDelay;
    public float spawnDelay;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWavesDelay);
        while(true)
        {
            yield return new WaitForSeconds(waveDelay);
            for (int i = 0; i < hazardWaves; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(spawnValues.z, spawnValues.z + 5));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}
