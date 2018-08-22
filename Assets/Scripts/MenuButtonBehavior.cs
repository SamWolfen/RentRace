using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum ButtonOption
{
    Play, Credits, Quit, Highscores, Pause, NextLevel
}

public class MenuButtonBehavior : MonoBehaviour {

    public ButtonOption buttonOption;
    public Button TargetButton;
    public string NextScene;

	// Use this for initialization
	void Start () {
        Button btn = TargetButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
	}
	
	void TaskOnClick()
    {
        

        switch (buttonOption)
        {
            case ButtonOption.Play:
                SceneManager.LoadScene(sceneName: "MainScene");
                break;

            case ButtonOption.NextLevel:
                SceneManager.LoadScene(sceneName: NextScene);
                break;
        }
    }
}
