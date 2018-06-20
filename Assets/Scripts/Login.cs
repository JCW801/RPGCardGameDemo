using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Assets.Scripts
{
    class Login : MonoBehaviour
    {
        public PlayerTransferModel player = new PlayerTransferModel();
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
            player.AccountName = userName.text;
            player.Password = passWord.text;
            GameClient.Client.Login(player.AccountName, player.Password, _callback);
        }

        private void _callback(PlayerTransferModel _player)
        {
            player = _player;
        }

        private void Update()
        {
            //throw new NotImplementedException();
            if (player != null && (player.TransferMessage != null || player.PlayerName != null))
            {
                go.SetActive(true);
                if (player.TransferState == PlayerTransferModel.TransferStateType.Error || player.TransferState == PlayerTransferModel.TransferStateType.Decline)
                {
                    connectInfo.text = player.TransferMessage;
                    player.TransferMessage = null;
                }
                else if (player.TransferState == PlayerTransferModel.TransferStateType.Accept)
                {
                    connectInfo.text = player.TransferMessage + "   载入中。。。请稍候";
                    StartCoroutine(LoadScene());
                }
            }
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("Start");
        }
        public void InputAgain()
        {
            go.SetActive(false);
        }
    }
}
