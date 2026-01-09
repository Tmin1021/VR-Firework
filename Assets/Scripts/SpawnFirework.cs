using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirework : MonoBehaviour
{
    [SerializeField] GameObject firework;
    [SerializeField] float spawnTime = 2f;
    private Transform spawnPosition;
    public bool ifLaunch = false;
    void Awake()
    {
        spawnPosition = GetComponent<Transform>();
    }

    public void Launch()
    {
        StartCoroutine(SpawnFwks());
    }

    IEnumerator SpawnFwks()
    {
        while(spawnPosition != null && ifLaunch == true) {
            Instantiate(firework, spawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
