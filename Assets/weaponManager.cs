using UnityEngine;

public class weaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate = 1;
    [SerializeField] bool semiAuto;
    float fireRateTimer;

    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    public float damage = 20;
    AimStateManager aim;



    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimStateManager>();
        fireRateTimer = fireRate;
    }

    void Update()
    {
        if (shouldFire())
            Fire();
    }

    bool shouldFire()
    {
        fireRateTimer += Time.deltaTime;

        if (fireRateTimer < fireRate)
            return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0))
            return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0))
            return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);
        audioSource.PlayOneShot(gunShot);
        for(int i= 0; i < bulletsPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.weapon = this;

            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}
