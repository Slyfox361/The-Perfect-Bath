using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactableScript : MonoBehaviour
{
    public string item = "none";
    public string searchText = "It seems to be empty...";
    public SpriteRenderer self;
    public GameObject bubble;
    public GameObject bubbleUI;

    // Start is called before the first frame update
    void Start()
    {
        self.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        self.enabled = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        self.enabled = false;
    }

    public void callBubble()
    {
        StartCoroutine(activateBubble());
        bubbleUI.SetActive(true);
    }

    IEnumerator activateBubble()
    {
        bubble.SetActive(true);
        yield return new WaitForSeconds(2f);
        bubble.SetActive(false);
    }
}
