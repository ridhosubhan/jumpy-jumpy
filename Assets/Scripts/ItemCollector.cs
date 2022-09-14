using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int kiwis = 0;

    [SerializeField] private Text kiwiText;
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Kiwi_Tag")){
            Destroy(collision.gameObject);
            kiwis++;
            kiwiText.text = "Kiwi : " + kiwis;
        }      
    }
}
