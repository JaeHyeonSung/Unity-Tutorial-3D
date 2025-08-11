using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDataGroup", menuName = "Scriptable Objects/WeaponDataGroup")]
public class WeaponDataGroup : ScriptableObject
{
    public WData[] wData;
}

[System.Serializable]
public class WData
{
    public string name;
    public DamageSystem damageSystem;
    public int range;
    public DetailData detailData;

}

[System.Serializable]
public class DetailData
{
    public int cost;
    public int upgradeLevel;
}

[System.Serializable]
public class DamageSystem
{
    public int minDamage;
    public int maxDamage;
    public int successPercent;
    public int criticalChance;
}