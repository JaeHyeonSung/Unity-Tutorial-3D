using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class FPSPlayerFire : MonoBehaviour
{
    private enum WeaponMode
    {
        Normal,
        Sniper
    }

    public GameObject[] eff_flash;

    private WeaponMode wMode;
    private bool isZoomMode = false;

    public Text wModeText;
    public GameObject firePosition;
    public GameObject bombFactory;

    public GameObject bulletEffect;

    public GameObject weapon01;
    public GameObject weapon02;

    public GameObject crossHair01;
    public GameObject crossHair02;
    public GameObject crossHair02_Zoom;

    public GameObject weapon01_R;
    public GameObject weapon02_R;
    ParticleSystem ps;
    private Animator anim;
    public int weaponPower = 5;
    private void Start()
    {
        NormalMode();
        wMode = WeaponMode.Normal;
        ps = bulletEffect.GetComponent<ParticleSystem>();
        anim = GetComponentInChildren<Animator>();
    }


    public float throwPower = 15f;
    private void Update()
    {
        if (FPSGameManager.gm.gState != FPSGameManager.GameState.Run)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wModeText.text = "Normal Mode";
            NormalMode();
            wMode = WeaponMode.Normal;
            Camera.main.fieldOfView = 60f;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wMode = WeaponMode.Sniper;
            SniperMode();
            wModeText.text = "Sniper Mode";
        }
        if (Input.GetMouseButtonDown(1))
        {
            switch (wMode)
            {
                case WeaponMode.Normal:
                    GameObject bomb = Instantiate(bombFactory);
                    bomb.transform.position = firePosition.transform.position;

                    Rigidbody rb = bomb.GetComponent<Rigidbody>();
                    rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
                    break;
                case WeaponMode.Sniper:
                    if (!isZoomMode)
                    {
                        crossHair02_Zoom.SetActive(true);
                        crossHair02.SetActive(false);
                        Camera.main.fieldOfView = 15f;
                        isZoomMode = true;
                    }
                    else
                    {
                        crossHair02_Zoom.SetActive(false);
                        crossHair02.SetActive(true);
                        Camera.main.fieldOfView = 60f;
                        isZoomMode = false;
                    }
                    break;
            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;

                    bulletEffect.transform.forward = hitInfo.normal;
                    ps.Play();
                }

            }
            StartCoroutine(ShootEffectOn(0.05f));
        }
    }
    IEnumerator ShootEffectOn(float duration)
    {
        int num = Random.Range(0, eff_flash.Length - 1);

        eff_flash[num].SetActive(true);

        yield return new WaitForSeconds(duration);

        eff_flash[num].SetActive(false);
    }

    public void NormalMode()
    {
        weapon01.SetActive(true);
        weapon02.SetActive(false);
        crossHair01.SetActive(true);
        crossHair02.SetActive(false);
        weapon01_R.SetActive(true);
        weapon02_R.SetActive(false);
        crossHair02_Zoom.SetActive(false);
        isZoomMode = false;
    }

    public void SniperMode()
    {
        weapon01.SetActive(false);
        weapon02.SetActive(true);
        crossHair01.SetActive(false);
        crossHair02.SetActive(true);
        weapon01_R.SetActive(false);
        weapon02_R.SetActive(true);
    }
}
