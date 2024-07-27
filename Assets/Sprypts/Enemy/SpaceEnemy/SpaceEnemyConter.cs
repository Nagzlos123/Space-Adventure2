using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceEnemyConter : MonoBehaviour
{
    public int activeEnemies;
    public int activeSpawners;


    [SerializeField] private Text enemiesTextNumber;
    [SerializeField] private Text spawnerTextNumber;
    [SerializeField] private GameObject portalPointer;
    [SerializeField] private GameObject portal;
     private Transform portalPointerCh;
    private Transform player;


    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        //portalPointerCh = portalPointer.transform.GetChild(0);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidbody2D = portalPointer.GetComponent<Rigidbody2D>();
        FindEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemies();
        LevelConclusion();
    }

    void FindEnemies()
    {
        activeEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        activeSpawners = GameObject.FindGameObjectsWithTag("Spawner").Length;
        enemiesTextNumber.text = activeEnemies.ToString();
        spawnerTextNumber.text = activeSpawners.ToString();
        Debug.Log("Number of activeEnemies" + activeEnemies);

    }

    void LevelConclusion()
    {
        
        if(activeEnemies == 0 && activeSpawners == 0)
        {
            portalPointer.SetActive(true);
            portal.SetActive(true);
            SetPointerDirection();
        }
        else
        {
            portalPointer.SetActive(false);
            portal.SetActive(false);
        }
    }

    void SetPointerDirection()
    {
        Vector3 direction = portal.transform.position - player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;
        rigidbody2D.rotation = angle;
    }
}
