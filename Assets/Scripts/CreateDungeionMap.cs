﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateDungeionMap : MonoBehaviour
{
    Dictionary<int, Dictionary<int, KeyValuePair<DungeonRoomTransferModel.RoomType, bool[]>>> dic
        = new Dictionary<int, Dictionary<int, KeyValuePair<DungeonRoomTransferModel.RoomType, bool[]>>>();
    // Use this for initialization
    GameObject prefab;
    public Transform mapPanel;
    GameObject[,] goArr;
    public GameObject lines;
    public Camera Uicamera;
    bool drag = false;
    Vector3 startPos;
    //Dictionary<int, Dictionary<int, GameObject>> gosdic;
    //public GameObject from;
    //public GameObject to;

    void Start()
    {
        //gosdic = new Dictionary<int, Dictionary<int, GameObject>>();
        List<Dungeon> dungeonsChosed = new List<Dungeon>();
        Player player = GameClient.Client.Player;
        dic = player.GetRoomMap();
        goArr = new GameObject[dic.Count, 7];
        prefab = Resources.Load("Image") as GameObject;
        Create();
    }

    // Update is called once per frame
    //void Update()
    //{

    //}
    //初始化界面图标
    public void Create()
    {
        //print("GetDicInfo,DicCount Is" + dic.Count);
        //初始化boss房间图标
        GameObject goBoss = Instantiate(prefab);
        goBoss.transform.SetParent(mapPanel);
        goBoss.transform.localPosition = new Vector3(0, (-600 + 200 * dic.Count - 1), 0);
        Sprite Bosssprite = new Sprite();
        Bosssprite = Resources.Load("RoomItemImage/BossRoom", typeof(Sprite)) as Sprite;
        goBoss.GetComponentInChildren<Image>().overrideSprite = Bosssprite;
        goBoss.transform.localScale = 3 * Vector3.one;

        //初始化所有房间图标
        for (int i = dic.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < 7; j++)
            {
                if (dic[i].ContainsKey(j) == false)
                {
                    continue;
                }
                GameObject go = Instantiate(prefab);
                //if (godic[i]==null)
                //{
                //    godic.Add(i, Dictionary<int, GameObject>);
                //}
                //godic[i].Add(j, go);

                //Dictionary<int, GameObject> godic = new Dictionary<int, GameObject>();
                //godic.Add(j, go);
                //gosdic.Add(i, godic);

                goArr[i, j] = go;
                go.transform.SetParent(mapPanel);
                go.transform.localPosition = new Vector3((-420 + 140 * j), (-800 + 200 * i), 0);

                Sprite sprite = new Sprite();
                switch (dic[i][j].Key)
                {
                    case DungeonRoomTransferModel.RoomType.NormalMonsterRoom:
                        sprite = Resources.Load("RoomItemImage/NormalMonsterRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.EliteMonsterRoom:
                        sprite = Resources.Load("RoomItemImage/EliteMonsterRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.TreasureRoom:
                        sprite = Resources.Load("RoomItemImage/TreasureRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.BossMonsterRoom:
                        sprite = Resources.Load("RoomItemImage/BossMonsterRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.ShoppingRoom:
                        sprite = Resources.Load("RoomItemImage/ShoppingRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.EventRoom:
                        sprite = Resources.Load("RoomItemImage/EventRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    case DungeonRoomTransferModel.RoomType.BonfireRoom:
                        sprite = Resources.Load("RoomItemImage/BonfireRoom", typeof(Sprite)) as Sprite;
                        go.GetComponentInChildren<Image>().overrideSprite = sprite;
                        break;
                    default:
                        break;
                }
                go.transform.localScale = Vector3.one;

                //图表之间连线
                if (i == dic.Count - 1)
                {
                    DrawLine(go, goBoss);
                }
                for (int k = 0; k < 3; k++)
                {
                    if (dic[i][j].Value[k])
                    {
                        DrawLine(go, goArr[i + 1, j + k - 1]);
                    }
                }
            }
        }
    }

    //public void Draw()
    //{
    //    DrawLine(from, to);
    //}

    //画线方法
    public void DrawLine(GameObject from, GameObject to)
    {
        GameObject line = Resources.Load("Line") as GameObject;
        line = Instantiate(line);
        line.transform.SetParent(lines.transform);
        //Vector3 _from= Camera.main.WorldToScreenPoint(from.transform.position);
        //Vector3 _to = Camera.main.WorldToScreenPoint(to.transform.position);
        Vector3[] vector3s = { from.transform.position, to.transform.position };
        line.GetComponent<LineRenderer>().SetPositions(vector3s);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("03WorldMap");
    }

    //界面滑动
    public void CameraMove()
    {
        if (Input.GetMouseButtonDown(0) == true && drag == false)
        {
            print("start drag");
            startPos = Input.mousePosition;
            drag = true;
        }
        else if (Input.GetMouseButtonDown(0) == true && drag == true)
        {
            drag = false;
        }

        if (drag == true)
        {
            //print("drag");
            //print("Input.mousePosition" + Input.mousePosition);
            //print("startPos" + startPos);
            print("Uicamera" + Uicamera.transform.localPosition);
            Vector3 move = Input.mousePosition - startPos;
            print("move.y" + move.y);
            if (Uicamera.transform.localPosition.y <= 1920 && move.y > 0)
            {
                Uicamera.transform.localPosition += (new Vector3(0, move.y, 0));
                //startPos = Input.mousePosition;
            }
            else if (Uicamera.transform.localPosition.y >= 0 && move.y < 0)
            {
                Uicamera.transform.localPosition += (new Vector3(0, move.y, 0));
                //startPos = Input.mousePosition;
            }
            startPos = Input.mousePosition;

        }
    }

    private void Update()
    {
        CameraMove();
    }
}
