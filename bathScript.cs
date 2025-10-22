using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bathScript : MonoBehaviour
{
    public bubbleScript[] bubbles;
    public int counter1 = 0;
    public int counter2 = 0;
    public bool full = false;
    public Transform camPos;
    public textScript textscript;
    float count = 100;
    int dialogueprogression = 1;
    public Transform speachbubblepos;

    // Start is called before the first frame update
    void Start()
    {
        counter2 = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        checkBubbles();

        if (counter2 == 9 && full == true)
        {
            Debug.Log("All 9");
            camPos.position = new Vector3(-0.27f, 14.43f, -10f);
            speachbubblepos.position = new Vector3(-0.33f, 16.35f, 0f);
            
            if (count == 100)
            {
                count = 0;
            }
        }

        if (count < 3 && dialogueprogression == 1)
        {
            if (textscript.running == false && textscript.bg.activeInHierarchy == false)
            {
                textscript.Start();
                switch(count)
                {
                    case 0:
                        textscript.printText("Now I just need to add them all to my bath!");
                        break;
                    case 1:
                        textscript.printText("Turn on the tap to fill it with hot water.");
                        break;
                    case 2:
                        textscript.printText("Then drag the bubbles into the bath!");
                        break;
                    case 3:
                        textscript.printText("Nice and slow so they don't pop...");
                        break;
                }
                count += 1;
            }
        }
        else if (count == 3 && dialogueprogression == 1)
        {
            dialogueprogression = 2;
            count = 100;
        }

        if (count < 3 && dialogueprogression == 2)
        {
            if (textscript.running == false && textscript.bg.activeInHierarchy == false)
            {
                textscript.Start();
                switch(count)
                {
                    case 0:
                        textscript.printText("Yay! I now have the perfect bath!");
                        break;
                    case 1:
                        textscript.printText("Thank you for the assistence!");
                        break;
                    case 2:
                        textscript.printText("*splashes about*");
                        break;
                }
                count += 1;
            }
        }
        else if (count == 3 && dialogueprogression == 2)
        {
            dialogueprogression = 3;
            count = 100;
        }
    }

    void checkBubbles()
    {
        counter1 = 0;
        for (int i=0;i<9;i++)
        {
            if (bubbles[i].onMe == true)
            {
                counter1++;
            }
        }

        if (counter1>1)
        {
            for (int i=0;i<9;i++)
            {
                bubbles[i].reset();
            }
        }
    }
}
