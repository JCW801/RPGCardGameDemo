using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Reflection;

namespace Assets.Scripts
{
    class Login : MonoBehaviour
    {
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
            userName.text = "TestPlayer1";
            passWord.text = "password1";
            playerModel.AccountName = userName.text;
            playerModel.Password = passWord.text;
            print("Login");
            go.SetActive(true);
            connectInfo.text = playerModel.TransferMessage + "   连接服务器中。。。请稍候";
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
                if (playerModel.TransferState == PlayerTransferModel.TransferStateType.Error || playerModel.TransferState == PlayerTransferModel.TransferStateType.Decline)
                {
                    connectInfo.text = playerModel.TransferMessage;
                    playerModel.TransferMessage = null;
                }
                else if (playerModel.TransferState == PlayerTransferModel.TransferStateType.Accept)
                {
                    connectInfo.text = playerModel.TransferMessage + "   载入中。。。请稍候";
                    StartCoroutine(LoadScene());
                }
            }
        }

        IEnumerator LoadScene()
        {
            //print("load");
            yield return new WaitForSeconds(1);
            print("Load02");
            SceneManager.LoadScene("02Start");
        }
        public void InputAgain()
        {
            go.SetActive(false);
        }
    }
}
