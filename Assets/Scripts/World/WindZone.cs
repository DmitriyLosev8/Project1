using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private ParticleSystem _windEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rock rock))
            Instantiate(_windEffect, transform.position, Quaternion.identity);
    }
}
