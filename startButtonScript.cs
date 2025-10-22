using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour
{
    public Button yourButton;
    public MCScript master;
    public Image startscreen;
    public Image self;

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
        master.intro();
        startscreen.gameObject.SetActive(false);
        self.gameObject.SetActive(false);
    }
}
