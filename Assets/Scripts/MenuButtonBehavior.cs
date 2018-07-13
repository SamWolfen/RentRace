using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum ButtonOption
{
    Play, Credits, Quit, Highscores, Pause 
}

public class MenuButtonBehavior : MonoBehaviour {

    public ButtonOption buttonOption;
    public Button button;

	// Use this for initialization
	void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	void TaskOnClick()
    {
        

        switch (buttonOption)
        {
            case ButtonOption.Play:
                SceneManager.LoadScene(sceneName: "MainScene");
                break;
        }
    }
}
