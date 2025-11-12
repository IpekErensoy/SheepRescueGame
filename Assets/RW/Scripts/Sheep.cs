using UnityEngine;

public class Sheep : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed;
    public float gotHayDestroyDelay;
    public float dropDestroyDelay;

    [Header("Hearts")]
    public float heartOffset;
    public GameObject heartPrefab;

    [Header("Special")]
    public bool isPink = false;   // Pembe koyun mu?

    private bool hitByHay = false;
    private bool hasDropped = false;

    private Collider myCollider;
    private Rigidbody myRigidbody;
    private SheepSpawner sheepSpawner;

    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Sürekli ileri doğru hareket
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Hay ile vurulma
        if (other.CompareTag("Hay") && !hitByHay && !hasDropped)
        {
            Destroy(other.gameObject);
            HitByHay();
        }
        // Aşağı düşme
        else if (other.CompareTag("DropSheep") && !hasDropped && !hitByHay)
        {
            Drop();
        }
    }

    private void HitByHay()
    {
        hitByHay = true;
        runSpeed = 0f;

        // Kalpler: pembe için 2, normal için 1
        int heartCount = isPink ? 2 : 1;

        for (int i = 0; i < heartCount; i++)
        {
            float xOffset = (i == 0) ? -0.4f : 0.4f;
            float yOffset = heartOffset + 0.2f * i;
            Instantiate(
                heartPrefab,
                transform.position + new Vector3(xOffset, yOffset, 0f),
                Quaternion.identity
            );
        }

        // Küçülerek kaybolma animasyonu
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0f;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;

        SoundManager.Instance.PlaySheepHitClip();

        // Puan: pembe = 2, normal = 1 (SavedSheep zaten sayıyı/puanı arttırıyor)
        int saveCount = isPink ? 2 : 1;
        for (int i = 0; i < saveCount; i++)
        {
            GameStateManager.Instance.SavedSheep();
        }

        // Bir süre sonra koyunu yok et
        Destroy(gameObject, gotHayDestroyDelay);
    }

    private void Drop()
    {
        hasDropped = true;

        GameStateManager.Instance.DroppedSheep();

        if (sheepSpawner != null)
        {
            sheepSpawner.RemoveSheepFromList(gameObject);
        }

        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;

        SoundManager.Instance.PlaySheepDroppedClip();

        Destroy(gameObject, dropDestroyDelay);
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
