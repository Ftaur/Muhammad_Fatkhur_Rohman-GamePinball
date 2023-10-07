using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
    }
    public Collider bola; // referensi ke bola
	public KeyCode input; // tombol input untuk aktivasi launch
    // untuk set berapa lama waktu yang harus dicapai hingga maksimal force
    public float maxTimeHold;
    // untuk set berapa besar maksimal force yang bisa didapat (ini menggantikan force)
    public float maxForce;
    // Untuk mengganti warna saat di hold Launcher nya
    public Material offMaterial;
    public Material onMaterial;
    private Renderer renderer;
    // state pada launcher
    private bool isHold;	
    private void Start()
    {
        // ambil renderernya
        renderer = GetComponent<Renderer>();
        // di set false state nya saat baru mulai
        isHold = false;
    }
	// hanya dapat membaca input saat bersentuhan dengan bola saja
	private void OnCollisionStay(Collision collision)
	{
		if (collision.collider == bola)
		{
            Debug.Log("Kena Bola");
			ReadInput(bola);
		}
	}
	
	// baca input
	private void ReadInput(Collider collider)
    {
        // di tambah adjustment agar tidak dijalankan saat sedang di hold
        if (Input.GetKey(input) && !isHold)
        {
            // disini langsung jalankan coroutine untuk mengkalkulasinya
            StartCoroutine(StartHold(collider));  
        }
        
        // Saat di hold akan menyalakan material On (secara terbalik)
        if (!isHold)
        {
            renderer.material = onMaterial;
        }
        else
        {
            renderer.material = offMaterial;
        }
    }

    // coroutine untuk fitur hold launcher
    private IEnumerator StartHold(Collider collider)
    {
        // di set true dulu
        isHold = true;
        
        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(input))
        {
            // renderer.material = onMaterial;
            // hitung force menggunakan lerp
            force = Mathf.Lerp(0, maxForce, timeHold/maxTimeHold);
                
            // tunggu step berikutnya dan naikan timer 
            // agar mendapat nilai force yang lebih besar dari sebelumnya
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime; 
        }
        // kalau tombol dilepas, maka proses hold selesai
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
    }
}
