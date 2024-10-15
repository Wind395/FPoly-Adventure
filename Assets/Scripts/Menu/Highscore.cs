using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class Highscore : MonoBehaviour
{
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform contentPanel;
    [SerializeField] private TextMeshProUGUI usernameText;
    [SerializeField] private TextMeshProUGUI highscoreText;


    string highscoreFilePath;
    private List<HighscoreEntry> highscoreEntries = new List<HighscoreEntry>();

    [System.Serializable]
    private class HighscoreEntry {
        public string name;
        public int score;

        public  HighscoreEntry(string name, int score) {
            this.name = name;
            this.score = score;
        }
    }


    void Start() {
        highscoreFilePath = Path.Combine(Application.persistentDataPath, "highscores.txt");
        Debug.Log("Highscore file path: " + highscoreFilePath);
        LoadHighscores();
        DisplayHighscores();
    }


    void DisplayHighscores() {
        foreach (Transform child in contentPanel) {
            Destroy(child.gameObject); // Clear existing rows
        }

        foreach (var entry in highscoreEntries) {
            GameObject newRow = Instantiate(rowPrefab, contentPanel);
            TextMeshProUGUI[] texts = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = entry.name; // Assuming the first text element is for username
            texts[1].text = entry.score.ToString(); // Assuming the second text element is for score
        }
    }
    void SaveHighscores() {
        using (StreamWriter writer = new StreamWriter(highscoreFilePath)) {
            foreach (var entry in highscoreEntries) {
                writer.WriteLine($"{entry.name},{entry.score}");
            }
        }
    }

    void LoadHighscores() {
    if (File.Exists(highscoreFilePath)) {
        highscoreEntries.Clear();
        try {
            using (StreamReader reader = new StreamReader(highscoreFilePath)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int score)) {
                        highscoreEntries.Add(new HighscoreEntry(parts[0], score));
                    }
                }
            }
            highscoreEntries = highscoreEntries.OrderByDescending(h => h.score).Take(5).ToList();
        } catch (Exception ex) {
            Debug.LogError($"Error loading highscores: {ex.Message}");
        }
    }
}

}