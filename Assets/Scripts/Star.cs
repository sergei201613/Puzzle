using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject graphics;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainBlock"))
        {
            particle.Play();

            GameMode.instance.starIsTaked = true;

            Destroy(graphics);
            Destroy(gameObject, 3f);
        }
    }
}
