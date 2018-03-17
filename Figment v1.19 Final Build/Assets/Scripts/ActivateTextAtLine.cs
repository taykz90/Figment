using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager theTextBox;

    public bool destroyWhenActivated;

	control p;

	//Counter for diary
	public int diaryCount=0;


	// Use this for initialization
	void Start () {

        theTextBox = FindObjectOfType<TextBoxManager>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//=========================================================
	public void setDiary(int d)
	{
		diaryCount+=d;
	}
	/*
	public void setDiary2()
	{
		diaryCount = 2;
	}

	public void setDiary3()
	{
		diaryCount = 3;
	}*/

	//=========================================================
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
			//Increase by one for every diary taken
			p=other.gameObject.GetComponent<control>();
			p.SetDiary (1);

            theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();


        if(destroyWhenActivated)
            {
                Destroy(gameObject);
            }

        }
    }
}
