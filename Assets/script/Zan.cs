using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zan : MonoBehaviour
{
    public int EnergyTotal { get; set; }
    public int SheildTotal { get; set; }
    public int LifeTotal { get; set; }
    public int sheildMax;
    public int zanMax;
    public int lifeMax;
    // Start is called before the first frame update
    void Awake()
    {
        // ³õÊ¼»¯´úÂë
        LifeTotal = lifeMax;
    }
    public void reset()
    {
        EnergyTotal = 0;
        SheildTotal = 0;
    }
    public void addEnergy()
    {
        if (EnergyTotal < zanMax)
        {
            EnergyTotal += 1;
        }
        addSheild();


    }
    public void useEnergy()
    {
        EnergyTotal=0;
        addSheild();
    }
    
    public void addSheild()
    {
        if (SheildTotal < sheildMax)
        {
            SheildTotal += 1;
        }
       
    }
    public void useSheild()
    {
        if (SheildTotal > 1)
        {
            SheildTotal -=1;
        }
    }
    
    public void lose()
    {
      
        LifeTotal -= 1;
    }
    public int getLife()
    {
        return LifeTotal;
    }

}
