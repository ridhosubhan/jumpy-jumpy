using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private FloatSO scoreSO;

    private void Start(){
        scoreText = "SCORE : " + scoreSO.Value;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
