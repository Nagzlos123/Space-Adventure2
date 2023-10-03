using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUpgradeManager : MonoBehaviour
{
    private int hpUpgrade;
    private int playerNormalHP;
    private int playerFullHP;
    private int attackUpgrade;
    [Header("Armor Settings")]
    public int fullArmor;
    public int normalArmor;
    public int helmetArmor;
    public int shouldersArmor;
    public int bodyArmor;
    public int pantsArmor;
    public int bootsArmor;
    public int glovesArmor;
    [Header("Health Settings")]
    public int fullHP;
    public int normalHP;
    public int shouldersHP;
    public int bodyArmorHP;
    public int pantsHP;

    [Header("Attack Settings")]
    public int fullAttack;
    public int normalAttack;
    public int shouldersAttack;
    public int glovesAttack;
    public int bracersAttack;

    [Header("Spaceship Settings")]
    public int spaceshipfullAttack;
    public int spaceshipnormalAttack;
    public int liser1Attack;
    public int liser2Attack;

    public int spaceshipfullHP;
    public int spaceshipnormalHP;
    public int engineHP;

    [SerializeField] private TextMeshProUGUI playerHP = null;
    [SerializeField] private TextMeshProUGUI playerAttack = null;
    [SerializeField] private TextMeshProUGUI playerArmor = null;
    [SerializeField] private TextMeshProUGUI spaceshipAttack = null;
    [SerializeField] private TextMeshProUGUI spaceshipHP = null;
    public int inventorySystemActive;
    private void Awake()
    {

    }
    private void Start()
    {
        ResetPlayerArmorAmplifiers();
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");

       
            PlayerPrefs.SetInt("PlayerNormalHP", 1000);
            PlayerPrefs.SetInt("PlayerNormalArmor", 500);
            PlayerPrefs.SetInt("PlayerNormalAttack", 20);

            PlayerPrefs.SetInt("StarshipNormalHP", 600);
            PlayerPrefs.SetInt("StarshipNormalAttack", 5);

            PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerNormalHP"));
            PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerNormalArmor"));
            PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerNormalAttack"));

            PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("StarshipNormalAttack"));
            PlayerPrefs.SetInt("SpaceshipFullHP", PlayerPrefs.GetInt("StarshipNormalHP"));
        





    }
    public void AddHelmetItemAmplifiers(int armor)
    {

        PlayerPrefs.SetInt("HelmetArmorAmplifier", armor);

        AddArmorPlayerStats();

    }

    public void SubtractHelmetItemAmplifiers(int armor)
    {

        PlayerPrefs.SetInt("HelmetArmorAmplifier", armor);

        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerFullArmor") - PlayerPrefs.GetInt("HelmetArmorAmplifier"));

        PlayerPrefs.SetInt("HelmetArmorAmplifier", 0);
    }

    public void AddShouldersItemAmplifiers(int hp, int armor, int attack)
    {
        PlayerPrefs.SetInt("ShouldersHPAmplifier", hp);
        PlayerPrefs.SetInt("ShouldersArmorAmplifier", armor);
        PlayerPrefs.SetInt("ShouldersAttackAmplifier", attack);

        AddArmorPlayerStats();
        AddHealthPlayerStats();
        AddAttackPlayerStats();

    }

    public void SubtractShouldersItemAmplifiers(int hp, int armor, int attack)
    {
        PlayerPrefs.SetInt("ShouldersHPAmplifier", hp);
        PlayerPrefs.SetInt("ShouldersArmorAmplifier", armor);
        PlayerPrefs.SetInt("ShouldersAttackAmplifier", attack);

        PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerFullHP") - PlayerPrefs.GetInt("ShouldersHPAmplifier"));
        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerFullArmor") - PlayerPrefs.GetInt("ShouldersArmorAmplifier"));
        PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerFullAttack") - PlayerPrefs.GetInt("ShouldersAttackAmplifier"));

        PlayerPrefs.SetInt("ShouldersHPAmplifier", 0);
        PlayerPrefs.SetInt("ShouldersArmorAmplifier", 0);
        PlayerPrefs.SetInt("ShouldersAttackAmplifier", 0);
    }

    public void AddBodyArmorItemAmplifiers(int hp, int armor)
    {

        PlayerPrefs.SetInt("BodyArmorHPAmplifier", hp);
        PlayerPrefs.SetInt("BodyArmorAmplifier", armor);

        AddArmorPlayerStats();
        AddHealthPlayerStats();

    }

    public void SubtractBodyArmorItemAmplifiers(int hp, int armor)
    {

        PlayerPrefs.SetInt("BodyArmorHPAmplifier", hp);
        PlayerPrefs.SetInt("BodyArmorAmplifier", armor);

        PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerFullHP") - PlayerPrefs.GetInt("BodyArmorHPAmplifier"));
        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerFullArmor") - PlayerPrefs.GetInt("BodyArmorAmplifier"));

        PlayerPrefs.SetInt("BodyArmorHPAmplifier", 0);
        PlayerPrefs.SetInt("BodyArmorAmplifier", 0);

    }

    public void AddPantsItemAmplifiers(int hp, int armor)
    {

        PlayerPrefs.SetInt("PantsHPAmplifier", hp);
        PlayerPrefs.SetInt("PantsArmorAmplifier", armor);

        AddArmorPlayerStats();
        AddHealthPlayerStats();


    }

    public void SubtractPantsItemAmplifiers(int hp, int armor)
    {

        PlayerPrefs.SetInt("PantsHPAmplifier", hp);
        PlayerPrefs.SetInt("PantsArmorAmplifier", armor);

        PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerFullHP") - PlayerPrefs.GetInt("PantsHPAmplifier"));
       PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerFullArmor") - PlayerPrefs.GetInt("PantsArmorAmplifier"));

        PlayerPrefs.SetInt("PantsHPAmplifier", 0);
        PlayerPrefs.SetInt("PantsArmorAmplifier", 0);

    }

    public void AddGlovesItemAmplifiers(int armor, int attack)
    {

        PlayerPrefs.SetInt("GlovesArmorAmplifier", armor);
        PlayerPrefs.SetInt("GlovesAttackAmplifier", attack);

        AddArmorPlayerStats();
        AddAttackPlayerStats();

    }

    public void SubtractGlovesItemAmplifiers(int armor, int attack)
    {

        PlayerPrefs.SetInt("GlovesArmorAmplifier", armor);
        PlayerPrefs.SetInt("GlovesAttackAmplifier", attack);

        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerFullArmor") - PlayerPrefs.GetInt("GlovesArmorAmplifier"));
        PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerFullAttack") - PlayerPrefs.GetInt("GlovesAttackAmplifier"));
        PlayerPrefs.SetInt("GlovesArmorAmplifier", 0);
        PlayerPrefs.SetInt("GlovesAttackAmplifier", 0);
    }
    public void AddBootsItemAmplifiers(int armor)
    {

        PlayerPrefs.SetInt("BootsArmorAmplifier", armor);

        AddArmorPlayerStats();

    }

    public void SubtractBootsItemAmplifiers(int armor)
    {

        PlayerPrefs.SetInt("BootsArmorAmplifier", armor);

        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerFullArmor") - PlayerPrefs.GetInt("BootsArmorAmplifier"));
        PlayerPrefs.SetInt("BootsArmorAmplifier", 0);
    }

    public void AddBracersItemAmplifiers(int attack)
    {

        PlayerPrefs.SetInt("BracersAttackAmplifier", attack);


        AddAttackPlayerStats();
    }

    public void SubtractBracersItemAmplifiers(int attack)
    {

        PlayerPrefs.SetInt("BracersAttackAmplifier", attack);

        PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerFullAttack") - PlayerPrefs.GetInt("BracersAttackAmplifier"));
        PlayerPrefs.SetInt("BracersAttackAmplifier", 0);
    }
    public void AddLiser1ItemAmplifiers(int attack)
    {

        PlayerPrefs.SetInt("Liser1AttackAmplifier", attack);
      

        AddAttackSpaceshipStats();

    }

    public void SubtractLiser1ItemAmplifiers(int attack)
    {

        PlayerPrefs.SetInt("Liser1AttackAmplifier", attack);

        PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("SpaceshipFullAttack") - PlayerPrefs.GetInt("Liser1AttackAmplifier"));
        PlayerPrefs.SetInt("Liser1AttackAmplifier", 0);

    }


    public void AddLiser2ItemAmplifiers(int attack)
    {

        PlayerPrefs.SetInt("Liser2AttackAmplifier", attack);
        //var liser2AttackAmplifier = PlayerPrefs.GetInt("Liser2AttackAmplifier");
        //Debug.Log("liser2AttackAmplifier =" + liser2AttackAmplifier);
        AddAttackSpaceshipStats();

    }

    public void SubtractLiser2ItemAmplifiers(int attack)
    {

        PlayerPrefs.SetInt("Liser2AttackAmplifier", attack);
        
        PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("SpaceshipFullAttack") - PlayerPrefs.GetInt("Liser2AttackAmplifier"));
        PlayerPrefs.SetInt("Liser2AttackAmplifier", 0); 

    }

    public void AddEngineItemAmplifiers(int hp)
    {

        PlayerPrefs.SetInt("EngineHPAmplifier", hp);

        AddpHealthSpaceshiStats();

    }

    public void SubtractEngineItemAmplifiers(int hp)
    {

        PlayerPrefs.SetInt("EngineHPAmplifier", hp);

        PlayerPrefs.SetInt("SpaceshipFullHP", PlayerPrefs.GetInt("SpaceshipFullHP") - PlayerPrefs.GetInt("EngineHPAmplifier"));
        PlayerPrefs.SetInt("EngineHPAmplifier", 0);
    }

    private void AddArmorPlayerStats()
    {
        PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerNormalArmor") + PlayerPrefs.GetInt("HelmetArmorAmplifier")
           + PlayerPrefs.GetInt("ShouldersArmorAmplifier") + PlayerPrefs.GetInt("BodyArmorAmplifier")
           + PlayerPrefs.GetInt("PantsArmorAmplifier") + PlayerPrefs.GetInt("BootsArmorAmplifier")
           + PlayerPrefs.GetInt("GlovesArmorAmplifier"));
    }

 
    
    private void AddHealthPlayerStats()
    {
        PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerNormalHP") + PlayerPrefs.GetInt("ShouldersHPAmplifier")
            + PlayerPrefs.GetInt("BodyArmorHPAmplifier") + PlayerPrefs.GetInt("PantsHPAmplifier"));
    }



    private void AddAttackPlayerStats()
    {
        PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerNormalAttack") + PlayerPrefs.GetInt("ShouldersAttackAmplifier")
            + PlayerPrefs.GetInt("GlovesAttackAmplifier") + PlayerPrefs.GetInt("BracersAttackAmplifier"));
    }



    private void AddAttackSpaceshipStats()
    {
        PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("StarshipNormalAttack") + PlayerPrefs.GetInt("Liser1AttackAmplifier")
            + PlayerPrefs.GetInt("Liser2AttackAmplifier"));
    }


    private void AddpHealthSpaceshiStats()
    {
        PlayerPrefs.SetInt("SpaceshipFullHP", PlayerPrefs.GetInt("StarshipNormalHP") + PlayerPrefs.GetInt("EngineHPAmplifier"));
    }


    public void ResetPlayerArmorAmplifiers()
    {
        PlayerPrefs.SetInt("PlayerFullArmor", 0);
        PlayerPrefs.SetInt("HelmetArmorAmplifier", 0);
        PlayerPrefs.SetInt("ShouldersArmorAmplifier", 0);
        PlayerPrefs.SetInt("BodyArmorAmplifier", 0);
        PlayerPrefs.SetInt("PantsArmorAmplifier", 0);
        PlayerPrefs.SetInt("BootsArmorAmplifier", 0);
        PlayerPrefs.SetInt("GlovesArmorAmplifier", 0);

        PlayerPrefs.SetInt("PlayerFullHP", 0);
        PlayerPrefs.SetInt("ShouldersHPAmplifier", 0);
        PlayerPrefs.SetInt("BodyArmorHPAmplifier", 0);
        PlayerPrefs.SetInt("PantsHPAmplifier", 0);

        PlayerPrefs.SetInt("PlayerFullAttack", 0);
        PlayerPrefs.SetInt("ShouldersAttackAmplifier", 0);
        PlayerPrefs.SetInt("GlovesAttackAmplifier", 0);
        PlayerPrefs.SetInt("BracersAttackAmplifier", 0);

        PlayerPrefs.SetInt("SpaceshipFullAttack", 0);
        PlayerPrefs.SetInt("Liser1AttackAmplifier", 0);
        PlayerPrefs.SetInt("Liser2AttackAmplifier", 0);
        PlayerPrefs.SetInt("SpaceshipFullHP", 0);
        PlayerPrefs.SetInt("EngineHPAmplifier", 0);

    }


    private void Update()
    {
        inventorySystemActive = PlayerPrefs.GetInt("InventorySystemActive");
        //Armor
        fullArmor = PlayerPrefs.GetInt("PlayerFullArmor");
        normalArmor = PlayerPrefs.GetInt("PlayNormalArmor");
        helmetArmor = PlayerPrefs.GetInt("HelmetArmorAmplifier");
        shouldersArmor = PlayerPrefs.GetInt("ShouldersArmorAmplifier");
        bodyArmor = PlayerPrefs.GetInt("BodyArmorAmplifier");
        bootsArmor = PlayerPrefs.GetInt("BootsArmorAmplifier");
        pantsArmor = PlayerPrefs.GetInt("PantsArmorAmplifier");
        glovesArmor = PlayerPrefs.GetInt("GlovesArmorAmplifier");
        //Health
        fullHP = PlayerPrefs.GetInt("PlayerFullHP");
        normalHP = PlayerPrefs.GetInt("PlayerNormalHP");
        shouldersHP = PlayerPrefs.GetInt("ShouldersHPAmplifier");
        bodyArmorHP = PlayerPrefs.GetInt("BodyArmorHPAmplifier");
        pantsHP = PlayerPrefs.GetInt("PantsHPAmplifier");
        //Attack
        fullAttack = PlayerPrefs.GetInt("PlayerFullAttack");
        normalAttack = PlayerPrefs.GetInt("PlayerNormalAttack");
        shouldersAttack = PlayerPrefs.GetInt("ShouldersAttackAmplifier");
        glovesAttack = PlayerPrefs.GetInt("GlovesAttackAmplifier");
        bracersAttack = PlayerPrefs.GetInt("BracersAttackAmplifier");
        //Spaceship
        spaceshipfullAttack = PlayerPrefs.GetInt("SpaceshipFullAttack");
        spaceshipnormalAttack = PlayerPrefs.GetInt("StarshipNormalAttack");
        liser1Attack = PlayerPrefs.GetInt("Liser1AttackAmplifier");
        liser2Attack = PlayerPrefs.GetInt("Liser2AttackAmplifier");

        spaceshipfullHP = PlayerPrefs.GetInt("SpaceshipFullHP");
        spaceshipnormalHP = PlayerPrefs.GetInt("StarshipNormalHP");
        engineHP = PlayerPrefs.GetInt("EngineHPAmplifier");

        SetPlayerStac();

        playerHP.text = PlayerPrefs.GetInt("PlayerFullHP").ToString();
        playerAttack.text = PlayerPrefs.GetInt("PlayerFullAttack").ToString();
        playerArmor.text = PlayerPrefs.GetInt("PlayerFullArmor").ToString();

        spaceshipAttack.text = PlayerPrefs.GetInt("SpaceshipFullAttack").ToString();
        spaceshipHP.text = PlayerPrefs.GetInt("SpaceshipFullHP").ToString();
    }

    private void SetPlayerStac()
    {
        if (inventorySystemActive == 1)
        {
            //ResetPlayerArmorAmplifiers();
            PlayerPrefs.SetInt("PlayerNormalHPSystem1", 1110);
            PlayerPrefs.SetInt("PlayerNormalArmorSystem1", 630);
            PlayerPrefs.SetInt("PlayerNormalAttackSystem1", 50);

            PlayerPrefs.SetInt("StarshipNormalHPSystem1", 1000);
            PlayerPrefs.SetInt("StarshipNormalAttackSystem1", 30);

            PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerNormalHPSystem1"));
            PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerNormalArmorSystem1"));
            PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerNormalAttackSystem1"));

            PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("StarshipNormalAttackSystem1"));
            PlayerPrefs.SetInt("SpaceshipFullHP", PlayerPrefs.GetInt("StarshipNormalHPSystem1"));

            playerHP.text = PlayerPrefs.GetInt("PlayerFullHP").ToString();
            playerAttack.text = PlayerPrefs.GetInt("PlayerFullAttack").ToString();
            playerArmor.text = PlayerPrefs.GetInt("PlayerFullArmor").ToString();

            spaceshipAttack.text = PlayerPrefs.GetInt("SpaceshipFullAttack").ToString();
            spaceshipHP.text = PlayerPrefs.GetInt("SpaceshipFullHP").ToString();

        }
        if (inventorySystemActive == 5)
        {
            //ResetPlayerArmorAmplifiers();
            //PlayerPrefs.SetInt("PlayerNormalHPSystem5", 1000);
            //PlayerPrefs.SetInt("PlayerNormalArmorSystem5", 500);
            //PlayerPrefs.SetInt("PlayerNormalAttackSystem5", 20);

            PlayerPrefs.SetInt("StarshipNormalHPSystem5", 1000);
            PlayerPrefs.SetInt("StarshipNormalAttackSystem5", 30);

            //PlayerPrefs.SetInt("PlayerFullHP", PlayerPrefs.GetInt("PlayerNormalHPSystem5"));
            //PlayerPrefs.SetInt("PlayerFullArmor", PlayerPrefs.GetInt("PlayerNormalArmorSystem5"));
            //PlayerPrefs.SetInt("PlayerFullAttack", PlayerPrefs.GetInt("PlayerNormalAttackSystem5"));

            PlayerPrefs.SetInt("SpaceshipFullAttack", PlayerPrefs.GetInt("StarshipNormalAttackSystem5"));
            PlayerPrefs.SetInt("SpaceshipFullHP", PlayerPrefs.GetInt("StarshipNormalHPSystem5"));

            playerHP.text = PlayerPrefs.GetInt("PlayerFullHP").ToString();
            playerAttack.text = PlayerPrefs.GetInt("PlayerFullAttack").ToString();
            playerArmor.text = PlayerPrefs.GetInt("PlayerFullArmor").ToString();

            spaceshipAttack.text = PlayerPrefs.GetInt("SpaceshipFullAttack").ToString();
            spaceshipHP.text = PlayerPrefs.GetInt("SpaceshipFullHP").ToString();

        }



    }

     
    
}
