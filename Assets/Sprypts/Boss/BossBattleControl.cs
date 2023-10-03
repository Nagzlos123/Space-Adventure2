using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleControl : MonoBehaviour
{
    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;
    [SerializeField] private GameObject boss;
    private Animator bossAnimator;

    private void Awake()
    {
        obstacle1.SetActive(false);
        obstacle2.SetActive(false);
        boss.SetActive(false);
        //bossAnimator = GetComponentInChildren<Animation>();
        bossAnimator = boss.GetComponent<BossP1Controler>().GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ProcessCollision(collider.gameObject);
    }
    void ProcessCollision(GameObject collider)
    {

        if (collider.CompareTag("Player"))
        {
            obstacle1.SetActive(true);
            obstacle2.SetActive(true);
            StartBossFight();
           
        }
    }

    private void StartBossFight()
    {
        
        boss.SetActive(true);
        bossAnimator.SetBool("Appear", true);
        bossAnimator.SetBool("Appear", false);

    }
}
