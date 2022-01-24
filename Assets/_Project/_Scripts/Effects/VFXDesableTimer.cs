using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class VFXDesableTimer : MonoBehaviour
{
    [SerializeField] float _secondsToCheckParticle = 0.3f;
    private ParticleSystem ps;

    public void Initialize(){
        Awake();
    }

    private void Awake()
    {
        SearchAndSetComponents();

    }

    private void SearchAndSetComponents()
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
            yield return new WaitForSeconds(_secondsToCheckParticle);
        }

        ps.gameObject.SetActive(false);
    }
}