using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInputToSingleton : MonoBehaviour
{
    public TMP_InputField text;
    public TMP_Text nameAndScore;
    //public TMP_Text high;

    // Start is called before the first frame update
    void Start()
    {
        nameAndScore.text=SaveLoadGame.sharedSaveLoadGame.highName+" -> "+SaveLoadGame.sharedSaveLoadGame.highScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void editToSingleton()
    {
        SaveLoadGame.sharedSaveLoadGame.tempName= text.text;
    }

}
