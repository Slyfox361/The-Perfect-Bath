using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapScript : MonoBehaviour
{
    public bool mouseDown = false;
    public bool onMe = false;
    public Vector3 mouseScreenPos;
    public Vector3 mouseScenePos;
    public Transform selfPos;
    public float size;
    public bathScript bath;
    public SpriteRenderer water;

    // Start is called before the first frame update
    void Start()
    {
        size = selfPos.localScale.x/2;
        water.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseScreenPos = Input.mousePosition;
        mouseScenePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseScenePos.z = 0;

        if (mouseScenePos.x >= selfPos.position.x - size && mouseScenePos.x <= selfPos.position.x + size && mouseScenePos.y >= selfPos.position.y - size && mouseScenePos.y <= selfPos.position.y + size)
        {
            onMe = true;
        }
        else
        {
            onMe = false;
        }

        if (Input.GetMouseButtonDown(0) && onMe == true)
        {
            Debug.Log("Click!");
            StartCoroutine(pouringWater());
        }
    }

    IEnumerator pouringWater()
    {
        water.enabled = true;
        yield return new WaitForSeconds(3f);
        water.enabled = false;
        Debug.Log("Bath Is Full!");
        bath.full = true;
    }
}
