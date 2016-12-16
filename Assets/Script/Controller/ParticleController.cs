using UnityEngine;
using System.Collections;
using System;

public class ParticleController : MonoBehaviour {

    public void DestroyParticle() {
        StartCoroutine(StarttCoroutine());
    }

    IEnumerator StarttCoroutine() {
        yield return new WaitForSeconds(GetComponentInChildren<ParticleSystem>().duration);
        Destroy(gameObject);
    }

    public void PlayParticle() {
        GetComponentInChildren<ParticleSystem>().Play();
        DestroyParticle();
    }
}
