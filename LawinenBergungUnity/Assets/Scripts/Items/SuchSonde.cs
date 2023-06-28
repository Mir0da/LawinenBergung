using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuchSonde : MonoBehaviour
{
    [SerializeField] private GameObject debugSnowPile;

    public void startStabAnimation()
    {
        StartCoroutine(CheckSnowPile(debugSnowPile));
    }

    private IEnumerator CheckSnowPile(GameObject snowPile)
    {
        int childCount = snowPile.transform.Find("Circle").childCount;
        for (int x = 0; x < childCount; x++)
        {
            Transform circleTransform = snowPile.transform.Find("Circle").GetChild(x);
            gameObject.transform.position = circleTransform.position;
            transform.LookAt(snowPile.transform);
            transform.position -= transform.forward * 5;
            //1f = time it takes to poke into the snow and pull it out again 
            StartCoroutine(probeStabAnimation(1f));
            yield return new WaitForSeconds(2f);
            
        }
        
    }

    private IEnumerator probeStabAnimation(float time)
    {
        float timePast = 0;
        while (timePast < time)
        {
           transform.position += Time.deltaTime * 2 * transform.forward;
           yield return null;
           timePast += Time.deltaTime;
        }

        while (timePast < time*2)
        {
            transform.position -= Time.deltaTime * 2 * transform.forward;
            yield return null;
            timePast += Time.deltaTime;
        }
    }
}
