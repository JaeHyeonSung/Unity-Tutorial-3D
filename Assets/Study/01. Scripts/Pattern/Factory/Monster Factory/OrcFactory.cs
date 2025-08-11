using NUnit.Framework.Constraints;
using UnityEngine;

public class OrcFactory : MonsterFactory
{
    protected override Monster CreateMonster(string type)
    {
        switch (type)
        {
            case "Normal":
                return new GameObject("Orc").AddComponent<Orc>();
            case "Warrior":
                return new GameObject("OrcWarrior").AddComponent<OrcWarrior>();
            case "Archer":
                return new GameObject("OrcArcher").AddComponent<OrcArcher>();
            default:
                Debug.Log($"Unknown Monster Type: {type}");
                break;

        }
        return null;
    }
}
