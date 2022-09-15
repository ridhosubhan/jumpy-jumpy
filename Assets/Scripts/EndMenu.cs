using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private FloatSO scoreSO;

    private void Start(){
        scoreText.text = "" + scoreSO.Value;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
