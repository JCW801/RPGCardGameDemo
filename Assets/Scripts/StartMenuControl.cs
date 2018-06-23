using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuControl : MonoBehaviour
{

    Player player;
    public Text HeroName;
    GameObject[] HeroModels;
    GameObject PresentHero ;
    AsyncOperation async;
    int index = 0;
    //public Button CreatNewRole;
    //public Button NextRole;
    //public Button LastRole;
    //public Button GetIn;
    // Use this for initialization
    void Start()
    {
        PresentHero = new GameObject();
        player = GameClient.Client.Player;
        HeroModels = new GameObject[player.PlayerHeros.Count];
        if (player.PlayerName != null && player.PlayerHeros.Count != 0)
        {
            //string name = player.PlayerHeros[index].GetHeroName();
            //HeroName.text = name;
            for (int i = 0; i < player.PlayerHeros.Count; i++)
            {
                string name =player.PlayerHeros[i].GetHeroName();
                HeroModels[i] = Resources.Load(name) as GameObject;
                HeroModels[i] = Instantiate(HeroModels[i]);
            }
            HeroName.text = HeroModels[index].name;
            PresentHero = HeroModels[index];
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
            //GameObject NextHero = (GameObject)(Resources.Load(player.PlayerHeros[index].GetHeroName()));
            HeroName.text = HeroModels[index].name;
            PresentHero = HeroModels[index];
        }        
    }
    public void LastOne()
    {
        if (index>0)
        {
            index--;
            //GameObject LastHero = (GameObject)(Resources.Load(player.PlayerHeros[index].GetHeroName()));
            HeroName.text = HeroModels[0].name;
            PresentHero = HeroModels[index];
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
