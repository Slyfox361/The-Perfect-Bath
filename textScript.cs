using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    public TMP_Text self;
    public GameObject bg;
    public bool running = false;
    public string text;
    public Coroutine cr;
    public GameObject speachBubble;

    // Start is called before the first frame update
    public void Start()
    {
        bg.SetActive(false);
        speachBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (bg.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("f") == true && running == false)
            {
                hideText();
            }
            else if (Input.GetKeyDown("f") == true && running == true)
            {
                skip();
            }
        }
    }

    void skip()
    {
        StopCoroutine(cr);
        self.SetText(text);
        running = false;
    }

    public void printText(string textToPrint)
    {
        bg.SetActive(true);
        speachBubble.SetActive(true);
        cr = StartCoroutine(printTextLoop(textToPrint));
    }

    IEnumerator printTextLoop(string textToPrint)
    {
        text = textToPrint;
        running = true;
        string temp = "";
        for (int i = 0; i < textToPrint.Length; i++)
        {
            temp += textToPrint[i];
            self.SetText(temp);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        running = false;
    }

    public void hideText()
    {
        self.SetText("");
        bg.SetActive(false);
        speachBubble.SetActive(false);
    }
}
