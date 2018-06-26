using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Models;

public class StartMenuControl : MonoBehaviour
{

    //Player player;
    public Text HeroName;
    GameObject[] HeroModels;
    GameObject PresentHero ;
    AsyncOperation async;
    int index = 0;
    bool isReadyToChangeScene = false;
    //public Button CreatNewRole;
    //public Button NextRole;
    //public Button LastRole;
    //public Button GetIn;
    // Use this for initialization
    void Start()
    {
        PresentHero = new GameObject();
        //player = GameClient.Client.Player;
        HeroModels = new GameObject[GameClient.Client.Player.PlayerHeros.Count];
        if (GameClient.Client.Player.PlayerName != null && GameClient.Client.Player.PlayerHeros.Count != 0)
        {
            //string name = player.PlayerHeros[index].GetHeroName();
            //HeroName.text = name;
            for (int i = 0; i < GameClient.Client.Player.PlayerHeros.Count; i++)
            {
                string name = GameClient.Client.Player.PlayerHeros.ToList()[i].GetHeroName();
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
        if (isReadyToChangeScene)
        {
            StartCoroutine(LoadScene());
        }
    }
    public void NextScene()
    {
        CardPlayerTransferModel cardPlayer = new CardPlayerTransferModel();
        cardPlayer.MainHero = "Warrior";
        cardPlayer.CardDic = GameClient.Client.GameDic.HeroDic["Warrior"].HeroBasicCard;

        GameClient.Client.EnterDungeon("TestDungeon", cardPlayer, EnterDungeon);
    }
    private void EnterDungeon(PlayerTransferModel player)
    {
        isReadyToChangeScene = true;
    }
    public void HeroModelControl()
    {

    }
    public void NextOne()
    {
        if (index< GameClient.Client.Player.PlayerHeros.Count-1)
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
        async = SceneManager.LoadSceneAsync("04DungeonMap");
        yield return async;
        //yield return new WaitForSeconds(1);
        //SceneManager.LoadScene("04DungeonMap");
    }
}
