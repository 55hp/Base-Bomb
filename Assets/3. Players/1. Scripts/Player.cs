using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject waitPos;
    [SerializeField] GameObject attackPos;
    bool puoiBattere;

    private void Start()
    {
        puoiBattere = true;
        waitPos.SetActive(true);
        attackPos.SetActive(false);
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && puoiBattere)
        {
            StartCoroutine(Batti());
        }

        if(Input.touchCount > 0 && puoiBattere)
        {
            StartCoroutine(Batti());
        }
    }


    /// <summary>
    /// Coroutine che avvia il movimento di battere con la mazza.
    /// </summary>
    /// <returns></returns>
    IEnumerator Batti()
    {
        puoiBattere = false;
        waitPos.SetActive(false);
        attackPos.SetActive(true);
        yield return new WaitForSeconds(0.3f);

        waitPos.SetActive(true);
        attackPos.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        puoiBattere = true;
    }

}
