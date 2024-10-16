using UnityEngine;
using UnityEngine.UI;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject objectToDestroy;  // Object ที่ต้องการทำลาย
    public Button destroyButton;        // ปุ่มหรือ Image ที่จะกดเพื่อทำลาย object

    private void Start()
    {
        // เช็คว่ามีการคลิกปุ่ม destroyButton หรือไม่
        destroyButton.onClick.AddListener(DestroyObject);
    }

    void DestroyObject()
    {
        // ตรวจสอบว่า object ไม่ได้ถูกทำลายไปก่อนแล้ว
        if (objectToDestroy != null)
        {
            // ทำลาย object ที่เรากำหนด
            Destroy(objectToDestroy);
        }
    }
}
