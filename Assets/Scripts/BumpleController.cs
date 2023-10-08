using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpleController : MonoBehaviour
{
    // untuk mengatur kecepatan bola setelah memantul
    public float multiplier;
    // menyimpan variabel bola sebagai referensi untuk pengecekan
	public Collider bola;
    // untuk mengatur warna bumper
    public Color color;
    // tambahkan audio manager untuk mengakses fungsi pada audio managernya
    public AudioManager audioManager;
    // tambahkan vfx manager untuk mengakses fungsi pada audio managernya
    public VFXManager VFXManager;
    // untuk mengakses score manager
    public ScoreManager scoreManager;
    public float score;
    // Untuk Animasi
    private Animator animator;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        // kita akses materialnya dan kita ubah warna nya saat Start
        renderer.material.color = color;
        // GetComponent<Renderer>().material.color = color;
        // ambil animatornya saat start
        animator = GetComponent<Animator>();
    }
	
	private void OnCollisionEnter(Collision collision)
	{
		// memastikan yang menabrak adalah bola
        if (collision.collider == bola)
        {
            // kita lakukan debug
            // Debug.Log("Kena Bola");
            // ambil rigidbody nya lalu kali kecepatannya sebanyak multiplier agar bisa memantul lebih cepat
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;
            // saat ditabrak oleh bola, kita tinggal aktifkan trigger Hit
            animator.SetTrigger("Hit");
            // kita jalankan SFX saat tabrakan dengan bola pada posisi tabrakannya
		    audioManager.PlaySFX(collision.transform.position);
            // kita jalankan VFX saat tabrakan dengan bola pada posisi tabrakannya
		    VFXManager.PlayVFX(collision.transform.position);
            //tambah score saat menabrak bumper
            scoreManager.AddScore(score);
        }
	}
}
