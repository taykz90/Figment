using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteCountUI : MonoBehaviour {

    public control diary;
    public Text noteCounter;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int i = diary.diaryCount;
        noteCounter.text = i.ToString() + " / 4";
    }
}
