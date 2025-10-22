using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bubbleScript : MonoBehaviour
{
    public bool mouseDown = false;
    public bool onMe = false;
    public Vector3 mouseScreenPos;
    public Vector3 mouseScenePos;
    public Transform selfPos;
    public Vector3 startPos;
    public bool inBath = false;
    public float size;
    public bathScript bath;
    public bool buffer = false;
    public Vector3 finalPos;
    public Rigidbody2D freezepos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = selfPos.position;
        size = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        mouseScreenPos = Input.mousePosition;
        mouseScenePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseScenePos.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }

        if (mouseScenePos.x >= selfPos.position.x - size && mouseScenePos.x <= selfPos.position.x + size && mouseScenePos.y >= selfPos.position.y - size && mouseScenePos.y <= selfPos.position.y + size && inBath == false)
        {
            onMe = true;
        }
        else
        {
            onMe = false;
        }

        if (mouseDown == true && onMe == true)
        {
            selfPos.position = mouseScenePos;
        }

        if (mouseDown == false && inBath == false)
        {
            reset();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "bath")
        {
            inBath = true;

            if (buffer == false)
            {
                buffer = true;
                bath.counter2++;
            }

            onMe = false;
            selfPos.position = finalPos;
            selfPos.localScale = new Vector3(2f,2f,2f);
            freezepos.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }

    public void reset()
    {
        selfPos.position = startPos;
    }
}
