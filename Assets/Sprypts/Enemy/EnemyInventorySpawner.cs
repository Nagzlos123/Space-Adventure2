using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInventorySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] jewelryItems;
    private GameObject[] armorItems;
    private GameObject[] potionsItems;
    private GameObject[] otherItems;

    [SerializeField] private GameObject[] ringsItems;
    [SerializeField] private GameObject[] earringsItems;
    [SerializeField] private GameObject[] necklacesItems;

    [SerializeField] private GameObject[] helmetsItems;
    [SerializeField] private GameObject[] bodyArmorItems;
    [SerializeField] private GameObject[] pantsItems;
    [SerializeField] private GameObject[] bootsItems;
    [SerializeField] private GameObject[] glovesItems;
    [SerializeField] private GameObject[] bracersItems;
    [SerializeField] private GameObject[] shouldersTtems;
    [SerializeField] private GameObject[] beltsTtems;

    private int numberOfItems;
    private int randomRingItem;
    private int randomEarringsItem;
    private int randomNecklacesItem;

    private int randomHelmetsItem;
    private int randomBodyArmorItem;
    private int randomPantsItem;
    private int randomBootsItem;
    private int randomGlovesItem;
    private int randomBracersItem;
    private int randomShouldersTtem;

    private int randomArmorItem;
    private int randomJewelryItem;
    public int itemsLength = 2;
    public int armorItemsLength;
    public int lewelryItemsLength;
    private void Start()
    {
        //GameObject[] jewelryItems = new GameObject[ringsItems[], earringsItems[], necklacesItems[]] ;
        randomHelmetsItem = Random.Range(0, itemsLength);
        randomHelmetsItem = Random.Range(0, itemsLength);
        randomBodyArmorItem = Random.Range(0, itemsLength);
        randomPantsItem = Random.Range(0, itemsLength);
        randomBootsItem = Random.Range(0, itemsLength);
        randomGlovesItem = Random.Range(0, itemsLength);
        randomBracersItem = Random.Range(0, itemsLength);
        randomShouldersTtem = Random.Range(0, itemsLength);
    }
    public void RandomInventorySet()
    {
        /*
        randomRingItem = Random.Range(0, itemsLength);
        randomEarringsItem = Random.Range(0, itemsLength);
        randomNecklacesItem = Random.Range(0, itemsLength);

        GameObject[] jewelryItems = { ringsItems[randomRingItem], earringsItems[randomEarringsItem], necklacesItems[randomNecklacesItem] };

        randomJewelryItem = jewelryItems.Length;

        randomJewelryItem = Random.Range(0, lewelryItemsLength);

        Instantiate(jewelryItems[randomJewelryItem], this.transform.position, Quaternion.identity);
        */
   


        GameObject[] armorItems = { helmetsItems[randomHelmetsItem], bodyArmorItems[randomBodyArmorItem], pantsItems[randomPantsItem],
            bootsItems[randomBootsItem], glovesItems[randomGlovesItem], bracersItems[randomBracersItem], shouldersTtems[randomShouldersTtem] };

        armorItemsLength = armorItems.Length;

        randomArmorItem = Random.Range(0, armorItemsLength);

        Instantiate(armorItems[randomArmorItem], this.transform.position, Quaternion.identity);


    }

    public void InstantiateRandomInventorySet()
    {
        Instantiate(armorItems[randomArmorItem], this.transform.position, Quaternion.identity);
        //newEnemyToSpawn = (GameObject)Instantiate(enemyToSpawn, spawnSpots[i].position, Quaternion.identity);
    }
}
