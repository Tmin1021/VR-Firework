using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkLogic : MonoBehaviour
{
    [SerializeField] GameObject explosionFX;
    [SerializeField] float explodeHeight;
    [SerializeField] float speed = 2f;
    private Transform fireworkTransform;
    private float initY;

    void Awake()
    {
        fireworkTransform = gameObject.GetComponent<Transform>();
        initY = fireworkTransform.position.y;
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
