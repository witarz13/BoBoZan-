using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArnaLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI countdownText;
    public Zan UserZan;
    public Zan enemyZan;
    public Button Zan, Hu, Bo, Pa;
    public GameObject replay;
    public GameObject attackPrefab,sheildPrefab,energyPrefab,enemyAttackPrefab,enemySheildPrefab,enemyEnergyPrefab;
    public AudioSource WinSound;
    public AudioSource LoseSound;
    private List<GameObject> spawnedPrefabs = new List<GameObject>();
    //private bool isButtonClicked = false;
    int userAction = 0;
    int enemyAction = 0;
    int counter = 0;
    bool gameEnd = false;


    void Start()
    {
        disableAllButton();
        replay.SetActive(gameEnd);
        StartCoroutine(CountdownAndAction());
        Zan.onClick.AddListener(() => SetButtonClicked(Zan));
        Hu.onClick.AddListener(() => SetButtonClicked(Hu));
        Bo.onClick.AddListener(() => SetButtonClicked(Bo));
        Pa.onClick.AddListener(() => SetButtonClicked(Pa));
    }
    public void reSet()
    {
        userAction = 0;
        enemyAction = 0;
        counter = 0;
        gameEnd = false;
        UserZan.EnergyTotal=0;
        UserZan.SheildTotal = 0;
        UserZan.LifeTotal = UserZan.lifeMax;
        enemyZan.EnergyTotal = 0;
        enemyZan.SheildTotal = 0;
        enemyZan.LifeTotal = enemyZan.lifeMax;
        disableAllButton();
        replay.SetActive(gameEnd);
        StartCoroutine(CountdownAndAction());
    }
    IEnumerator CountdownAndAction()
    {
        // 倒计时部分
        for (int count = 3; count > 0; count--)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "";
        while (!gameEnd)
        {
            if (UserZan.LifeTotal<=0)
            {
                countdownText.fontSize = 72;
                countdownText.text = "You Lose!!";
                gameEnd=true;
                disableAllButton();
                replay.SetActive(gameEnd);
            }
            else if (enemyZan.LifeTotal <= 0)
            {
                countdownText.fontSize = 72;
                countdownText.text = "You Win!!";
                gameEnd = true;
                disableAllButton();
                replay.SetActive(gameEnd);

            }
            if (counter > 2 && counter % 4 == 3)//user action area
            {
                
                Zan.interactable = true;
                Hu.interactable = checkHu();
                Bo.interactable = checkBo();
                Pa.interactable = false;
            }
            else if (counter > 2 && counter % 4 == 0)//if no action, assume user use Zan
            {
                if (userAction == 0)
                {
                    UserZan.addEnergy();
                    userAction = 1;

                }
                computerAiAction();
                actionIcon(userAction, enemyAction);
                int fightResult = result(userAction, enemyAction);//结算
                Debug.Log("user:" + userAction + " enemy: " + enemyAction + " resutl: " + fightResult);
                if (fightResult == 1)
                {
                    enemyZan.lose();
                    WinSound.Play();
                }
                else if (fightResult == -1)
                {
                    UserZan.lose();
                    LoseSound.Play();
                }
                userAction = 0;
            }
            else//no button allow in paipai status
            {
                
                Pa.interactable = true;
                foreach (GameObject obj in spawnedPrefabs)
                {
                    Destroy(obj);
                }
                spawnedPrefabs.Clear();
            }
            counter += 1;
            yield return new WaitForSeconds(1); // 每秒检查一次

        }


    }
   
    private bool checkHu()
    {
        if (UserZan.SheildTotal >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool checkBo()
    {
        if (UserZan.EnergyTotal >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void SetButtonClicked(Button clicked)
    {
        if (clicked == Zan)
        {
            userAction=1;
            disableAllButton();
        }
        else if (clicked == Hu)
        {
            userAction=2;
            disableAllButton();
        }
        else if (clicked == Bo)
        {
            userAction=3;
            disableAllButton();
        }
        else if (clicked == Pa)
        {
            
            disableAllButton();
        }
    }
    private void disableAllButton()
    {
        Zan.interactable = false;
        Hu.interactable = false;
        Bo.interactable = false;
        Pa.interactable = false;
    }
    
    private int result(int userAction,int enemyAction)
    {
        
        if (userAction== enemyAction)
        {
            if (userAction == 1)
            {
                return 0;
            }
            else if (userAction == 2)
            {
                return 0;
            }
            else
            {
                if (UserZan.EnergyTotal > enemyZan.EnergyTotal)
                {
                    return 1;
                }
                else if(UserZan.EnergyTotal < enemyZan.EnergyTotal)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
        else
        {
            if(userAction==3 && enemyAction != 2)
            {
                return 1;
            }
            else if (enemyAction==3 && userAction != 2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    void actionIcon(int userAction,int enemyAction)
    {
        if (userAction == 1)
        {
            GameObject item = Instantiate(energyPrefab, new Vector3(950, 265, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(item);
        }
        else if (userAction == 2)
        {
            GameObject item = Instantiate(sheildPrefab, new Vector3(950, 265, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(item);
        }
        else
        {
            GameObject item = Instantiate(attackPrefab, new Vector3(950, 265, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(item);
        }
        if (enemyAction == 1)
        {
            GameObject item = Instantiate(enemyEnergyPrefab, new Vector3(950, 650, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(item);
        }
        else if (enemyAction == 2)
        {
            GameObject item = Instantiate(enemySheildPrefab, new Vector3(950, 650, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(item);
        }
        else
        {
            GameObject item = Instantiate(enemyAttackPrefab, new Vector3(950, 650, 0), Quaternion.identity, transform);
            spawnedPrefabs.Add(item);
        }
    }
    private void computerAiAction()
    {
        if(UserZan.SheildTotal==0 & enemyZan.EnergyTotal > 1)
        {
            enemyZan.useEnergy();
            enemyAction = 3;
        }
        else if (enemyZan.EnergyTotal > 5)
        {
            bool randomBool = UnityEngine.Random.value < 0.7f;
            if (randomBool)
            {
                enemyZan.useEnergy();
                enemyAction = 3;
            }
            else
            {
                bool randomBoolsub = UnityEngine.Random.value < 0.5f;
                if (randomBoolsub && enemyZan.SheildTotal>1)
                {
                    enemyZan.useSheild();
                    enemyAction = 2; 

                }
                else
                {
                    enemyZan.addEnergy();
                    enemyAction = 1;
                }
            }
        }
        else if(enemyZan.EnergyTotal > 1)
        {
            bool attackBool = UnityEngine.Random.value < 0.3f;
            if (attackBool)
            {
                enemyZan.useEnergy();
                enemyAction = 3;
            }
            else
            {
                bool sheildkBool = UnityEngine.Random.value < 0.5f;
                if (sheildkBool && enemyZan.SheildTotal > 1)
                {
                    enemyZan.useSheild();
                    enemyAction = 2;

                }
                else
                {
                    enemyZan.addEnergy();
                    enemyAction = 1;
                }
            }
        }
        else
        {
            bool sheildkBool = UnityEngine.Random.value < 0.5f;
            if (sheildkBool && enemyZan.SheildTotal > 1)
            {
                enemyZan.useSheild();
                enemyAction = 2;

            }
            else
            {
                enemyZan.addEnergy();
                enemyAction = 1;
            }
        }
    }

}
