using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxSource;
    private void Start()
	{
		// kita langsung hapus game objectnya setelah 1 detik
		Destroy(gameObject, 1.0f);
	}
	public void PlayVFX(Vector3 spawnPosition)
	{
		// spawn vfx pada posisi sesuai parameter
		GameObject.Instantiate(vfxSource, spawnPosition, Quaternion.identity);
	}
}
