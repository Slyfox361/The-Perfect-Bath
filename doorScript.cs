using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public Transform campos;
    public Transform playerpos;
    public Vector3 newcampos;
    public Vector3 newplayerpos;
    public bool locked = true;
    public SpriteRenderer self;

    // Start is called before the first frame update
    void Start()
    {
        self.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void openDoor()
    {
        campos.position = newcampos;
        playerpos.position = newplayerpos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        self.enabled = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        self.enabled = false;
    }
}
