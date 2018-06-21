using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Assets.Scripts
{
    class Login : MonoBehaviour
    {
        public static Player Player { get; private set; }
        private PlayerTransferModel playerModel = new PlayerTransferModel();
        public InputField userName;
        public InputField passWord;
        public Text connectInfo;
        public GameObject go;
        private void Start()
        {
            GameClient.Client.ConnectToServer(null);
        }
        public void GetPlayerLoginInfo()
        {
            playerModel.AccountName = userName.text;
            playerModel.Password = passWord.text;
            print("Login");
            GameClient.Client.Login(playerModel.AccountName, playerModel.Password, _callback);
        }

        private void _callback(PlayerTransferModel _player)
        {
            playerModel = _player;
        }

        private void Update()
        {
            //throw new NotImplementedException();
            if (playerModel != null && (playerModel.TransferMessage != null || playerModel.PlayerName != null))
            {
                go.SetActive(true);
                if (playerModel.TransferState == PlayerTransferModel.TransferStateType.Error || playerModel.TransferState == PlayerTransferModel.TransferStateType.Decline)
                {
                    connectInfo.text = playerModel.TransferMessage;
                    playerModel.TransferMessage = null;
                }
                else if (playerModel.TransferState == PlayerTransferModel.TransferStateType.Accept)
                {
                    Player = new Player(playerModel, JsonConvert.DeserializeObject<GameDictionary>(JToken.Parse(File.ReadAllText("GameDic.json")).ToString()));
                    connectInfo.text = playerModel.TransferMessage + "   载入中。。。请稍候";
                    StartCoroutine(LoadScene());
                }
            }
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("02Start");
        }
        public void InputAgain()
        {
            go.SetActive(false);
        }
    }
}
