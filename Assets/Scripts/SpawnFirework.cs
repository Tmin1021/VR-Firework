using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirework : MonoBehaviour
{
    [SerializeField] GameObject firework;
    [SerializeField] float spawnTime = 2f;
    private Transform spawnPosition;

    void Awake()
    {
        spawnPosition = GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFwks());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnFwks()
    {
        while(spawnPosition != null) {
            Instantiate(firework, spawnPosition.position + Vector3.up * 2f, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
