using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hintButtonScript : MonoBehaviour
{
    public Button yourButton;
    public textScript text;
    public bubbleUIScript[] bubblesUI;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        check();
    }

    void check()
    {
        for (int i=0;i<9;i++)
        {
            if (bubblesUI[i].gameObject.activeInHierarchy == false)
            {
                text.printText(bubblesUI[i].hint);
                break;
            }
        }
    }
}
