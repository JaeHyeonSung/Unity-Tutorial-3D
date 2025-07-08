using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int age, string name, float height, float weight)
    {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
    }
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    void Start()
    {
        persons.Add("Ã¶¼ö", new PersonData(10, "Ã¶¼ö", 150f, 30f));
        persons.Add("¿µÈñ", new PersonData(10, "¿µÈñ", 150f, 30f));
        persons.Add("µ¿¼ö", new PersonData(10, "µ¿¼ö", 150f, 30f));

        Debug.Log(persons["Ã¶¼ö"].age);
        Debug.Log(persons["Ã¶¼ö"].name);
        Debug.Log(persons["Ã¶¼ö"].height);
        Debug.Log(persons["Ã¶¼ö"].weight);
    }
}