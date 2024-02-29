using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleobject : MonoBehaviour
{
 private Vector3 initialScale;

    // Faktor perubahan skala
    public Vector3 scaleChange = new Vector3(1.5f, 1.5f, 1.5f);

    // Layer yang akan menyebabkan perubahan skala
    public LayerMask collisionLayer;

    void Start()
    {
        // Simpan skala awal objek
        initialScale = transform.localScale;
    }

    // Ketika terjadi tabrakan dengan objek lain
    void OnCollisionEnter(Collision collision)
    {
        // Periksa apakah objek yang bertabrakan berada pada lapisan yang diinginkan
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            // Ubah skala objek
            transform.localScale += scaleChange;
        }
    }

    // Ketika terjadi kontak berkepanjangan dengan objek lain
    void OnCollisionStay(Collision collision)
    {
        // Periksa apakah objek yang bertabrakan berada pada lapisan yang diinginkan
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            // Tambahkan kode sesuai kebutuhan
        }
    }

    // Ketika tabrakan dengan objek tertentu selesai
    void OnCollisionExit(Collision collision)
    {
        // Periksa apakah objek yang bertabrakan berada pada lapisan yang diinginkan
        if (((1 << collision.gameObject.layer) & collisionLayer) != 0)
        {
            // Kembalikan skala objek ke skala awal
            transform.localScale = initialScale;
        }
    }
}
