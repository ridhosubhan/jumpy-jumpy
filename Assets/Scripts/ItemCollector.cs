using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // private int kiwis = 0;

    [SerializeField] private Text kiwiText;
    [SerializeField] private FloatSO scoreSO;

    [SerializeField] private AudioSource collectItemSoundEffects;

    private void Start(){
        kiwiText.text = scoreSO.Value.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Kiwi_Tag")){
            collectItemSoundEffects.Play();
            Destroy(collision.gameObject);
            scoreSO.Value = scoreSO.Value+1;
            kiwiText.text = scoreSO.Value.ToString();
        }      
    }
}
