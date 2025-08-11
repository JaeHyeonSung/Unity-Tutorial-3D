using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }

    public List<CharacterData> characters = new List<CharacterData>();

    void Start()
    {
        //var dataFile = Resources.Load<TextAsset>("CsvData");
        var dataFile = Resources.Load<TextAsset>("TsvData");
        string data = dataFile.text;

        ParsingCharacterData(data);
    }

    private void ParsingCharacterData(string data)
    {
        Debug.Log(data);

        string[] rows = data.Split('\n');
        for (int i = 1; i < rows.Length; i++)
        {
            //string[] cols = rows[i].Split(',');
            string[] cols = rows[i].Split('\t');
            CharacterData characterData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));

            characters.Add(characterData);
        }


    }

}
