using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public WeaponSO weaponData;

    public Camera fpsCam;
    public ParticleSystem Muzzle;
    public GameObject impactEf;

    private float nextTimeFire = 0f;

    private float damage;
    private float range;
    private float fireRate;
    private float impactForce;
    private AudioSource shootingAudioSource;

    private AudioManager audioManager;

    /* Nuevo */
    private void Start()
    {
        audioManager = AudioManager.instance;
        damage = weaponData.damage;
        range = weaponData.range;
        fireRate = weaponData.fireRate;
        impactForce = weaponData.impactForce;
        SetSoundEffect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeFire)
        {
            nextTimeFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        if (Muzzle) Muzzle.Play();
        if (shootingAudioSource) shootingAudioSource.Play();
        else Debug.LogWarning("There's no muzzle effect for active gun");
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage); 
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impact = Instantiate(impactEf, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1.5f);
        }
    }

    void SetSoundEffect()
    {
        Sound s = audioManager.soundEffects[(int)weaponData.weaponName];
        shootingAudioSource = gameObject.AddComponent<AudioSource>();
        s.source = shootingAudioSource;
        s.source.clip = s.clip;
        s.source.volume = audioManager.sfxVolume;
        s.source.loop = s.loop;
        s.source.playOnAwake = s.playOnAwake;
        s.source.pitch = s.pitch;
        s.source.panStereo = s.stereoPan;
    }
}
