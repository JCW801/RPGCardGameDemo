using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuControl : MonoBehaviour {

    PlayerTransferModel player;
    public Text HeroName;
    public GameObject HeroModel;
    //public Button CreatNewRole;
    //public Button NextRole;
    //public Button LastRole;
    //public Button GetIn;
	// Use this for initialization
	void Start ()
    {
        player = GameClient.Client.player;
        string name = player.PlayerHeroList[0];
        HeroName.text = name;
        HeroModel = (GameObject)(Resources.Load(name));
        HeroModel = Instantiate(HeroModel);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void NextScene()
    {

    }
    public void HeroModelControl()
    {

    }   
    public void NextOne()
    {

    }
    public void LastOne()
    {

    }
    public void CreatRole()
    {

    }
}
