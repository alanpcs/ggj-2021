using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocksSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _sockPrefab;
    private float _timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        _timeSpawn = 3.0f;
        StartCoroutine(SpawnSocks());
    }


    IEnumerator SpawnSocks ()
    {
        yield return new WaitForSeconds(_timeSpawn);
        _timeSpawn *= 1.5f;
        float x = Random.Range(-4.3f, 4.3f);
        float y = Random.Range(-4.3f, 4.3f);

        // 19.36 = r * r
        while ((x*x + y*y) > 19.36f)
        {
            x = Random.Range(-4.3f, 4.3f);
            y = Random.Range(-4.3f, 4.3f);
        }
        Vector3 position = new Vector3(x, y, 0);
        GameObject spawned = Instantiate(_sockPrefab, position, Quaternion.identity);
        StartCoroutine(SpawnSocks());
    }
}
