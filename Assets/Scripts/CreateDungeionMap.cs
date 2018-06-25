using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using UnityEngine.UI;

public class CreateDungeionMap : MonoBehaviour
{
    Dictionary<int, Dictionary<int, KeyValuePair<DungeonRoomTransferModel.RoomType,bool[]>>> dic 
        = new Dictionary<int, Dictionary<int,KeyValuePair<DungeonRoomTransferModel.RoomType,bool[]>>>();
    // Use this for initialization
    GameObject prefab;
    public Transform mapPanel;
    void Start()
    {
        List<Dungeon> dungeonsChosed = new List<Dungeon>();
        dic = GameClient.Client.Player.GetRoomMap();
        prefab = Resources.Load("DungeonRoomImage") as GameObject;
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        //if (dic!=null)
        //{
        //    print("dic has fulled"+dic.Count);
        //}
    }
    public void Create()
    {
        print("dic has fulled" + dic.Count);
        for (int i = 0; i < dic.Count; i++)
        {
            for (int j = 0; j < dic[i].Count; j++)
            {
                GameObject go= Instantiate(prefab);
                go.transform.SetParent(mapPanel);
                go.GetComponent<Image>().sprite.name = dic[i][j].Key.ToString();
                go.transform.position=new Vector3((-420 + 120 * j), -800, 0);
            }
        }
    }
    public void DrawLine(GameObject from, GameObject to)
    {

    }
}
