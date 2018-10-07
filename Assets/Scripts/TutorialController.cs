using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{   
    private int _currentDialog;
    
    public Image TutorialPanel;
    public List<Sprite> Dialogs;

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void NextDialog()
    {
        _currentDialog++;
        if (_currentDialog >= Dialogs.Count)
        {
            Time.timeScale = 1;
            TutorialPanel.gameObject.SetActive(false);
        }
        else
        {
            TutorialPanel.sprite = Dialogs[_currentDialog];
        }
    }
}