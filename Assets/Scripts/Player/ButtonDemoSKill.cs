using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDemoSKill : MonoBehaviour
{
    public Button button;
    public bool isAction = true;

    void Start()
    {
        button.onClick.AddListener(OnClickButton);    
    }

    
    void Update()
    {
        if (isAction)
        {
            //button nhấn
            button.interactable = true;
            //màu sáng
            button.GetComponent<Image>().color = Color.white;

        }
        else
        {
            button.interactable = false;

            button.GetComponent <Image>().color = Color.gray;
        }
    }

    void OnClickButton()
    {
        if(isAction)
        {
            isAction = false;
            StartCoroutine(ResetActionStateAfterDelay(10f));
        }
    }
    IEnumerator ResetActionStateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isAction = true;
    }
}
