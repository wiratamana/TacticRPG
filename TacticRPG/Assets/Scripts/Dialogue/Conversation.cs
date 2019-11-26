using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace TacticRPG
{
    public class Conversation : MonoBehaviour
    {
        private struct ConversationUtil
        {
            public string name;
            public string dialogue;

            public ConversationUtil(string name, string dialogue)
            {
                this.name = name;
                this.dialogue = dialogue;
            }
        }

        [SerializeField] private GameObject characterLeft;
        [SerializeField] private GameObject characterRight;
        [SerializeField] private GameObject clickToContinue;

        [SerializeField] private Text characterName;
        [SerializeField] private Text dialogue;

        private bool isBreak;
       
        void Start()
        {
            var chat = new Queue<ConversationUtil>();
            chat.Enqueue(new ConversationUtil("Uzumaki Naruto", "Selamat pagi, Sasuke."));
            chat.Enqueue(new ConversationUtil("Uchiha Sasuke", "Selamat pagi, Naruto."));
            chat.Enqueue(new ConversationUtil("Uzumaki Naruto", "Rasengan!!"));
            chat.Enqueue(new ConversationUtil("Uchiha Sasuke", "Chidori!!"));

            StartCoroutine(GenerateText(chat));
        }

        public void OnClick()
        {
            if(isBreak == true)
            {
                return;
            }

            isBreak = true;
        }

        private IEnumerator GenerateText(Queue<ConversationUtil> chat)
        {
            var twentyWordPerSeconds = new WaitForSeconds(0.05f);

            while (chat.Count > 0)
            {
                var stringBuilder = new StringBuilder();
                var dialogue = chat.Dequeue();

                characterName.text = dialogue.name;

                foreach (var c in dialogue.dialogue)
                {
                    if (isBreak == true)
                    {
                        break;
                    }

                    stringBuilder.Append(c);
                    this.dialogue.text = stringBuilder.ToString();

                    yield return twentyWordPerSeconds;
                }

                if (isBreak == true)
                {
                    isBreak = false;
                    continue;
                }

                clickToContinue.SetActive(true);

                while (isBreak == false)
                {
                    yield return null;
                }

                clickToContinue.SetActive(false);

                isBreak = false;
            }

            if (chat.Count == 0)
            {
                SM.Instance.ChangeScene(SM.SceneList.BattlePreparation);
            }
        }
    }
}
