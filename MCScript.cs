using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MCScript : MonoBehaviour
{

    public Transform trans;
    public float speed = 0.25f;
    public textScript textscript;
    int count = 100;
    public int glycerineNo = 0;
    public int soapNo = 0;
    public int oilNo = 0;
    public bool freeMovement = false;
    int dialogueprogression = 1;
    public doorScript kitchenDoor;
    public doorScript basementDoor;
    public doorScript bathroomDoor;
    public SpriteRenderer mcspriteren;
    public float currentDirection = 1f;
    public Animator anim;
    public Transform speachBubble;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speachBubble.position = trans.position + new Vector3(-0.15f,0.8f,0f);

        if (glycerineNo == 3 && kitchenDoor.locked == true)
        {
            finishedInRoom(kitchenDoor);
        }
        else if (soapNo == 3 && bathroomDoor.locked == true)
        {
            finishedInRoom(bathroomDoor);
        }
        else if (oilNo == 3 && count == 100)
        {
            count = 0;
        }

        if (count < 3 && dialogueprogression == 1)
        {
            if (textscript.running == false && textscript.bg.activeInHierarchy == false)
            {
                textscript.Start();
                switch(count)
                {
                    case 0:
                        textscript.printText("I need to find the items for a perfect bath!");
                        break;
                    case 1:
                        textscript.printText("I first need 3 small bottles of glycerine!");
                        break;
                    case 2:
                        textscript.printText("They must be around here somewhere...");
                        break;
                }
                count += 1;
            }
        }
        else if (count == 3 && dialogueprogression == 1)
        {
            freeMovement = true;
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
                        textscript.printText("I've found all the bottles!");
                        break;
                    case 1:
                        textscript.printText("Now I need to find 3 bars of soap...");
                        break;
                    case 2:
                        textscript.printText("I think they're in the basement. Luckily, i just found the key!");
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

        if (count < 4 && dialogueprogression == 3)
        {
            if (textscript.running == false && textscript.bg.activeInHierarchy == false)
            {
                textscript.Start();
                switch(count)
                {
                    case 0:
                        textscript.printText("I've found all the soap!");
                        break;
                    case 1:
                        textscript.printText("All I need now is my bath bombs...");
                        break;
                    case 2:
                        textscript.printText("I last saw them in the bathroom, I think my brother is done in there now...");
                        break;
                    case 3:
                        textscript.printText("Hopefully, he hasn't made a mess...");
                        break;
                }
                count += 1;
            }
        }
        else if (count == 4 && dialogueprogression == 3)
        {
            dialogueprogression = 4;
            count = 100;
        }

        if (count < 2 && dialogueprogression == 4)
        {
            if (textscript.running == false && textscript.bg.activeInHierarchy == false)
            {
                textscript.Start();
                switch(count)
                {
                    case 0:
                        textscript.printText("I've found all the bath bombs!");
                        break;
                    case 1:
                        textscript.printText("Now i can have my perfect bath!");
                        break;
                }
                count += 1;
            }
        }
        else if (count == 2 && dialogueprogression == 4)
        {
            dialogueprogression = 5;
            count = 100;
        }
    }

    void FixedUpdate()
    {
        if (freeMovement == true)
        {
            float moveInputH = Input.GetAxisRaw("Horizontal");
            float moveInputV = Input.GetAxisRaw("Vertical");
            trans.position = new Vector3(trans.position.x + (moveInputH*speed),trans.position.y + (moveInputV*speed),trans.position.z);

            if (moveInputH != 0)
            {
                currentDirection = moveInputH;
            }

            if (moveInputH != 0 || moveInputV != 0)
            {
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
            }

            if (currentDirection == 1)
            {
                mcspriteren.flipX = false;
            }
            else
            {
                mcspriteren.flipX = true;
            }
        }
    }

    public void intro()
    {
        //tutorialText();
        count = 0;
    }

    void finishedInRoom(doorScript door)
    {
        count = 0;
        door.locked = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.tag == "interactable")
        {
            //Debug.Log("Close to Drawerer");
            if (Input.GetKeyDown("e") == true && textscript.running == false)
            {
                interactableScript thingscript = col.collider.GetComponent<interactableScript>();
                if (thingscript.item == "none")
                {
                    textscript.printText(thingscript.searchText);
                }
                else if (thingscript.item == "glycerine")
                {
                    textscript.printText("I found some glycerine!");
                    thingscript.callBubble();
                    glycerineNo++;
                }
                else if (thingscript.item == "soap")
                {
                    textscript.printText("I found some soap!");
                    thingscript.callBubble();
                    soapNo++;
                }
                else if (thingscript.item == "oil")
                {
                    textscript.printText("I found a bath bomb!");
                    thingscript.callBubble();
                    oilNo++;
                }
                thingscript.item = "none";
            }
        }
        else if (col.collider.tag == "door")
        {
            //Debug.Log("Close to Door");
            if (Input.GetKeyDown("e") == true)
            {
                //Debug.Log("Opened Door");
                doorScript ds = col.collider.GetComponent<doorScript>();
                if (ds.locked == false)
                {
                    ds.openDoor();
                }
                else
                {
                    textscript.printText("It's locked...");
                }
            }
        }

        else if (col.collider.tag == "bath")
        {
            if (Input.GetKeyDown("e") == true)
            {
                if (oilNo == 3)
                {
                    SceneManager.LoadScene("bathScene");
                }
                else
                {
                    textscript.printText("I'm still missing some bath bombs...");
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "drawerer")
        {
            Debug.Log("Close");
        }
    }
}
