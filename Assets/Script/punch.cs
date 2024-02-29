using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MoveObject : MonoBehaviour
{
 // Kecepatan pergerakan objek
    public float speed = 1.0f;
    // Posisi semula objek
    private Vector3 originalPosition;
    // Posisi tujuan objek
    private Vector3 targetPosition;
    // Apakah objek sedang bergerak
    private bool isMoving = false;

    // Update dijalankan setiap frame
    void Update()
    {
        // Jika tombol spasi ditekan dan objek tidak sedang bergerak
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            // Set posisi semula objek
            originalPosition = transform.position;
            // Tentukan posisi tujuan objek
            targetPosition = originalPosition + Vector3.forward;
            // Mulai perpindahan objek
            StartCoroutine(MoveObjectCoroutine());
        }
    }

    // Coroutine untuk perpindahan objek
    IEnumerator MoveObjectCoroutine()
    {
        isMoving = true;
        float elapsedTime = 0f;
        
        // Mulai pergerakan objek
        while (elapsedTime < 1f)
        {
            // Interpolasi antara posisi semula dan posisi tujuan
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime);
            // Update waktu yang telah berlalu
            elapsedTime += Time.deltaTime * speed;
            yield return null;
        }

        // Pastikan objek berada di posisi tujuan
        transform.position = targetPosition;

        // Tunggu selama 1 detik
        yield return new WaitForSeconds(0.1f);

        // Kembalikan objek ke posisi semula
        StartCoroutine(ReturnObjectCoroutine());
    }

    // Coroutine untuk mengembalikan objek ke posisi semula
    IEnumerator ReturnObjectCoroutine()
    {
        float elapsedTime = 0f;
        
        // Mulai pergerakan objek kembali ke posisi semula
        while (elapsedTime < 1f)
        {
            // Interpolasi antara posisi tujuan dan posisi semula
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime);
            // Update waktu yang telah berlalu
            elapsedTime += Time.deltaTime * speed;
            yield return null;
        }

        // Pastikan objek berada di posisi semula
        transform.position = originalPosition;

        // Objek telah selesai bergerak
        isMoving = false;
    }

}
