using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{

    Player player;
    public Text HeroName;
    GameObject HeroModel;
    AsyncOperation async;
    int index = 0;
    //public Button CreatNewRole;
    //public Button NextRole;
    //public Button LastRole;
    //public Button GetIn;
    // Use this for initialization
    void Start()
    {
        player = GameClient.Client.Player;
        if (player.PlayerName != null && player.PlayerHeros.Count != 0)
        {
            string name = player.PlayerHeros[index].GetHeroName();
            HeroName.text = name;
            HeroModel = (GameObject)(Resources.Load(name));
            HeroModel = Instantiate(HeroModel);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NextScene()
    {
        StartCoroutine(LoadScene());
    }
    public void HeroModelControl()
    {

    }
    public void NextOne()
    {
        if (index< player.PlayerHeros.Count-1)
        {
            index++;
            GameObject NextHero = (GameObject)(Resources.Load(player.PlayerHeros[index].GetHeroName()));
            HeroModel = NextHero;
        }        
    }
    public void LastOne()
    {
        if (index>0)
        {
            index--;
            GameObject LastHero = (GameObject)(Resources.Load(player.PlayerHeros[index].GetHeroName()));
            HeroModel = LastHero;
        }        
    }
    public void CreatRole()
    {

    }
    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("03DungeonMap");
        yield return async;
    }
}
