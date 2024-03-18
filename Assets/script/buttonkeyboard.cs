using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonkeyboard : MonoBehaviour
{
    // Start is called before the first frame update
    public Button Pabutton; // ������İ�ť
    public Button Attackbutton;
    public Button Sheildbutton;
    public Button Energybutton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Pabutton.interactable==true)
        {
            Pabutton.onClick.Invoke(); // ������ť�ĵ���¼�
        }
        if (Input.GetKeyDown(KeyCode.Q) && Energybutton.interactable == true)
        {
            Energybutton.onClick.Invoke(); // ������ť�ĵ���¼�
        }
        if (Input.GetKeyDown(KeyCode.W) && Sheildbutton.interactable == true)
        {
            Sheildbutton.onClick.Invoke(); // ������ť�ĵ���¼�
        }
        if (Input.GetKeyDown(KeyCode.E) && Attackbutton.interactable == true)
        {
            Attackbutton.onClick.Invoke(); // ������ť�ĵ���¼�
        }
    }
}
