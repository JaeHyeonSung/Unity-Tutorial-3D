using UnityEngine;

public abstract class MonsterFactory : MonoBehaviour
{
    public Monster SpawnMonster(string type)
    {
        Monster monster = CreateMonster(type);

        return monster;
    }

    protected abstract Monster CreateMonster(string type);
}
