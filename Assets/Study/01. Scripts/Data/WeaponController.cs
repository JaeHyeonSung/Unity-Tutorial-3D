using UnityEngine;

namespace Data.SO
{
    public class WeaponController : MonoBehaviour
    {
        public WeaponData[] weaponData;
        public GameObject[] weaponObjects;


        private string currentWeaponName;
        private int currentWeaponDamage;
        private int currentWeaponRange;
        private void Start()
        {
            foreach (var data in weaponData)
            {
                Debug.Log($"{data.weaponName}, {data.weaponDamage}, {data.attackRange}");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwapWeapon(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwapWeapon(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwapWeapon(2);
            }
        }

        private void SwapWeapon(int index)
        {
            foreach(var weapon in weaponObjects)
            {
                weapon.SetActive(false);
            }
            weaponObjects[index].SetActive(true);

            currentWeaponName = weaponData[index].weaponName;
            currentWeaponDamage = weaponData[index].weaponDamage;
            currentWeaponRange = weaponData[index].attackRange;
        }
    }
}
