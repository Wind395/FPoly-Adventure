using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ConversationManager : MonoBehaviour, IPointerClickHandler
{
    public static ConversationManager Instance;
    [SerializeField] private List<ConversationLine> conversations = new List<ConversationLine>();
    [SerializeField] private TextMeshProUGUI speaker;
    [SerializeField] private TextMeshProUGUI content;
    public static int currentConversationIndex = 0;
    public static int nextConversation = 0;
    [SerializeField] private GameObject chatboxUI;

    private bool isConversationCompleted = false;


    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadConversation("conversation1");
        GetNextConversation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadConversation(string path) {
        conversations.Clear();
        TextAsset loadText = Resources.Load<TextAsset>(path);
        if (loadText != null)
        {
            Debug.Log("Exist");
            string[] lines = loadText.text.Split('\n');
            foreach (string line in lines)
            {
                string[] parts = line.Split('\t');
                if (parts.Length == 2)
                {
                    Debug.Log("Added");
                    Debug.Log(parts[0]);
                    Debug.Log(parts[1]);
                    conversations.Add(new ConversationLine(parts[0], parts[1]));

                }
                else
                {
                    Debug.LogWarning("Invalid dialogue line: " + line);
                }
            }
        }
        else
        {
            Debug.LogError("Dialogue file not found at " + path);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetNextConversation();
        currentConversationIndex++;
    }

    public void GetNextConversation() {
        if (currentConversationIndex < conversations.Count) {
            speaker.text = conversations[currentConversationIndex].name;
            content.text = conversations[currentConversationIndex].content;
        }
        if (currentConversationIndex >= conversations.Count) {
            chatboxUI.SetActive(false);
            isConversationCompleted = true;
            if (isConversationCompleted) {
                nextConversation++;
                isConversationCompleted = false;
            }
            currentConversationIndex = 0;
            Debug.Log(currentConversationIndex);
            Debug.Log(nextConversation);
            conversations.Clear();
        }
    }
}

[System.Serializable]
    public class ConversationLine {
        public string name;
        public string content;

        public ConversationLine(string name, string content) {
            this.name = name;
            this.content = content;
        }
    }