using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class LeaderboardController : MonoBehaviour
{
    public InputField memberID;
    public Text playerScore;
    public int ID;
    int maxScores = 6;
    public Text[] entries;   

    void Start(){
        LootLockerSDKManager.StartSession("Subhan", (response) =>{
            if(response.success){
                Debug.Log("sucess");
            }
            else{
                Debug.Log("Failed : "   + response);
            }
        });
    }

    public void ShowScore(){
        LootLockerSDKManager.GetScoreList(ID, maxScores, (response) => {
            if(response.success){
                LootLockerLeaderboardMember[] scores =  response.items;

                for(int i=0; i < scores.Length; i++){
                    entries[i].text = (scores[i].rank + ". " + scores[i].member_id + ": " + scores[i].score);
                }

                if(scores.Length < maxScores){
                    for(int i=scores.Length; i<maxScores; i++){
                        entries[i].text = (1+1).ToString() + ". none";
                    }   
                }
            }
            else{
                Debug.Log("Failed : "   + response);
            }
        });
    }

    public void SubmitScore(){
        LootLockerSDKManager.SubmitScore(memberID.text, int.Parse(playerScore.text), ID, (response) => {
            if(response.success){
                Debug.Log("sucess");
            }
            else{
                Debug.Log("Failed : "   + response);
            }
        });
    }
}
