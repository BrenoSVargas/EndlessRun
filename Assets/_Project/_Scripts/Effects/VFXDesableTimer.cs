using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class VFXDesableTimer : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();

    }

    void OnEnable()
    {
        if (ps == null)
        {
            return;
        }

        StartCoroutine(CheckIfAlive());
    }

    IEnumerator CheckIfAlive()
    {

        while (ps.IsAlive(true))
        {
            if (!ps.IsAlive(true))
            {
                break;
            }
            yield return new WaitForSeconds(0.5f);
        }

        ps.gameObject.SetActive(false);



    }
}