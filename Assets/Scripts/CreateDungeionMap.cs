using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using UnityEngine.UI;

public class CreateDungeionMap : MonoBehaviour
{
    Dictionary<int, Dictionary<int, KeyValuePair<DungeonRoomTransferModel.RoomType, bool[]>>> dic
        = new Dictionary<int, Dictionary<int, KeyValuePair<DungeonRoomTransferModel.RoomType, bool[]>>>();
    // Use this for initialization
    GameObject prefab;
    public Transform mapScroll;
    public GameObject from;
    public GameObject to;
    
    void Start()
    {
        //List<Dungeon> dungeonsChosed = new List<Dungeon>();
        //Player player = GameClient.Client.Player;
        //dic = player.GetRoomMap();
        //prefab = Resources.Load("Image") as GameObject;
        //Create();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Create()
    {
        print("GetDicInfo,DicCount Is" + dic.Count);
        for (int i = 0; i < dic.Count; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (dic[i].ContainsKey(j) == false)
                {
                    continue;
                }
                GameObject go = Instantiate(prefab);
                go.transform.SetParent(mapScroll);
                go.transform.localPosition = new Vector3((-420 + 140 * j), (-800 + 200 * i), 0);

                Sprite sprite = new Sprite();
                switch (dic[i][j].Key)
                {
                    case DungeonRoomTransferModel.RoomType.NormalMonsterRoom:
                        sprite = Resources.Load("NormalMonsterRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.EliteMonsterRoom:
                        sprite = Resources.Load("EliteMonsterRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.TreasureRoom:
                        sprite = Resources.Load("TreasureRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.BossMonsterRoom:
                        sprite = Resources.Load("BossMonsterRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.ShoppingRoom:
                        sprite = Resources.Load("ShoppingRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.EventRoom:
                        sprite = Resources.Load("EventRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.BonfireRoom:
                        sprite = Resources.Load("BonfireRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    default:
                        break;
                }


            }
        }
    }

    public void Draw()
    {
        DrawLine(from, to);
    }

    public void DrawLine(GameObject from, GameObject to)
    {
        GameObject line = Resources.Load("Line") as GameObject;
        line = Instantiate(line);
        Vector3 _from= Camera.main.WorldToScreenPoint(from.transform.position);
        Vector3 _to = Camera.main.WorldToScreenPoint(to.transform.position);
        Vector3[] vector3s = { from.transform.position, to.transform.position };
        line.GetComponent<LineRenderer>().SetPositions(vector3s);
    }

}
