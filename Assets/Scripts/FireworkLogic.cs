using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkLogic : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] float minExplodeHeight = 8f;
    [SerializeField] float maxExplodeHeight = 10f;
    [SerializeField] float minSpeed = 1.5f;
    [SerializeField] float maxSpeed = 3f;
    private float speed = 2f;
    private Transform fireworkTransform;
    private float initY;
    private float explodeHeight;
    void Awake()
    {
        fireworkTransform = gameObject.GetComponent<Transform>();
        initY = fireworkTransform.position.y;
    }
    void Start()
    {
        explodeHeight = Random.Range(minExplodeHeight, maxExplodeHeight);
        speed = Random.Range(minSpeed, maxSpeed);
    }
    void Update()
    {
        LaunchFireWork();
    }

    void LaunchFireWork()
    {
        fireworkTransform.position = Vector3.Lerp(fireworkTransform.position, fireworkTransform.position + Vector3.up * explodeHeight, Time.deltaTime * speed);
        if(fireworkTransform.position.y >= initY + explodeHeight)
        {
            Destroy(gameObject);
            Instantiate(explosionFX, fireworkTransform.position, Quaternion.identity);
        }
    }
}
