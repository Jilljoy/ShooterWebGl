using UnityEngine;
using System;

/// <summary>
/// A quick and dirty projectile controller. (ie bullets)
/// </summary>
public class ProjectileController : MonoBehaviour
{

    private void Start() {
        Destroy(gameObject, 2.0f);   
    }

    void Update()
    {
        transform.Translate(transform.forward * 0.5f, Space.World);
    }
}
