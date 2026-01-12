using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirework : MonoBehaviour
{
    [SerializeField] GameObject firework;
    [SerializeField] float spawnTime = 2f;
    private Transform spawnPosition;
    private Coroutine coroutine = null;
    private bool ifLaunch = false;
    void Awake()
    {
        spawnPosition = GetComponent<Transform>();
    }
    // void Start()
    // {
    //     SetLaunch(true);
    // }
    public void SetLaunch(bool value)
    {
        ifLaunch = value;
        if(ifLaunch)
        {
            if(coroutine == null)
            {
                coroutine = StartCoroutine(SpawnFwks());
            }
        }
        else
        {
            if(coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }

    IEnumerator SpawnFwks()
    {
        while(spawnPosition != null && ifLaunch == true) {
            Instantiate(firework, spawnPosition.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
        }

        coroutine = null;
    }
}
