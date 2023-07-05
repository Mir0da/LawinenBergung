using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shovel : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject rightSnowPile;
    Animator animator;
    private AudioSource audioSrc;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void takeShovel()
    {
        //transform.parent.parent = player.transform;
        
        //translate shovel to a better position
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        float attachDistance = 0.9f;
        
        Vector3 attachPos = playerPos + playerDirection*attachDistance;
        //attachPos.x += 0.5f;
        attachPos.y -= 0.7f;
        transform.parent.position = attachPos;
        transform.parent.rotation = playerRotation;
        animator.SetTrigger("takeShovelTrigger");
        Debug.Log("Shovel Equipped!");
    }

    private void playDiggSound()
    {
        Debug.Log("Play Sound");
        audioSrc.Play();
    }
    
    public void startDigAnimation()
    {
        Debug.Log("Start Coroutine!");
        StartCoroutine(CheckSnowPile(rightSnowPile));
    }
    
    private IEnumerator CheckSnowPile(GameObject snowPile)
    {
        int childCount = snowPile.transform.Find("Piles").childCount;
        Debug.Log("Child Count:" + childCount);
        for (int x = 0; x < childCount; x++)
        {
            Transform pilesTransform = snowPile.transform.Find("Piles").GetChild(0);
            
            Debug.Log(pilesTransform.position);
            
            Vector3 temp= pilesTransform.position;
            temp.y += 1f;
            gameObject.transform.parent.position = temp;
      

            animator.SetTrigger("shovelDigTrigger");
            yield return new WaitForSeconds(0.7f);
            playDiggSound();
            Debug.Log("Destroy Pile" + x);
            Destroy(pilesTransform.gameObject);
            yield return new WaitForSeconds(2f);
        }
        
        //wait for after digging to not let the scene end too fast
        yield return new WaitForSeconds(4f);
        InteractionManager.ready = true;
    }
}