using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    // enum untuk mengatur state
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    // Menyimpan variabel bola sebagai refrensi untuk pengecekan
    public Collider bola;
    // menyimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;
    // menyimpan state switch apakah nyala atau mati
    // menggantikan isOn
    private SwitchState state;
    // komponen renderer pada object yang akan diubah
    private Renderer renderer;
    private void Start()
    {
        // ambil renderernya
        renderer = GetComponent<Renderer>();

        // set switch nya mati baik di state, maupun materialnya
        // isOn = false;
        // renderer.material = offMaterial;

        // set switch nya mati baik di state, maupun materialnya
	    Set(false);
        // pada fungsi start mulai langsung jalankan timer
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        // Memastikan yang menabrak adalah bola
        if (other == bola)
        {
            // Debug.Log("Kena Bola");
            // kita matikan atau nyalakan switch sesuai dengan kebalikan state switch tersebut
            // mati --> nyala || nyala --> mati
            // Set(!isOn);
            // diubah menjadi toggle
            Toggle();
        }
    }

    // fungsi set diubah menjadi menggunakan enum
    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            // hentikan proses blink
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            // saat dimatikan, lagsung mulai timer nya
            StartCoroutine(BlinkTimerStart(5));
        }
    }
    
    // fungsi untuk on off
    private void Toggle()
    {
        // dari on --> off
        if (state == SwitchState.On)
        {
            Set(false);
        }
        // dari off --> on atau blink --> on
        else
        {
            Set(true);
        }
    }

    // blink diubah total
    private IEnumerator Blink(int times)
    {
        // set statenya menjadi blink dulu sebelum mulai proses
        state = SwitchState.Blink;

        // mulai proses blink tanpa mengubah state lagi
        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        // set menjadi off kembali setelah proses blink
        state = SwitchState.Off;

        // saat selesai blink, mulai juga timer nya
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
