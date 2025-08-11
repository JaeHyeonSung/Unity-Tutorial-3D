using UnityEngine;

namespace Data.SO
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public int weaponDamage;
        public int attackRange;
    }
}
