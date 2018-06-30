using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Models;

public class EnterDungeonRoom : MonoBehaviour {


    // Use this for initialization
    public int depth;
    public int index;
    int currentIndex = 0;
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Enter()
    {
        //print(index);
        //Player player = GameClient.Client.Player;
        //DungeonRoom dungeonRoom= GameClient.Client.Player.GetCurrentRoom();
        print("GetInDungeon" + depth + "," + index);
        if (GameClient.Client.Player.GetCurrentRoom()!=null)
        {
            currentIndex = GameClient.Client.Player.GetCurrentRoom().RoomIndex;
        }
        print("回传给服务器进入dungeon的值： " + (index - currentIndex));
        GameClient.Client.EnterDungeonRoom(index - currentIndex,LoadScene);
        //GameClient.Client.Player.EnterDungeonRoom(index-GameClient.Client.Player.GetCurrentRoom().RoomIndex);
        
    }
    public void LoadScene(PlayerTransferModel player)
    {
        if (player.TransferState == PlayerTransferModel.TransferStateType.Accept)
        {
            //var i = GameClient.Client.Player.GetCurrentRoom().RoomDepth;
            //var ind = GameClient.Client.Player.GetCurrentRoom().RoomIndex;
            //SceneManager.LoadScene("05Fight");

            //播一个花圈的动画
        }

    }
}
