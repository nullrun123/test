using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas targetCanvas;  // Canvas ที่ต้องการเปิด
    public GameObject targetObject;  // Object ที่ต้องการให้คลิกเพื่อเปิด Canvas

     void Start()
    {
        targetCanvas.gameObject.SetActive(false);
        targetCanvas.gameObject.SetActive(false);
        targetCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // ตรวจสอบการคลิกเมาส์ซ้าย
        if (Input.GetMouseButtonDown(0))
        {
            // สร้าง Ray จากตำแหน่งของเมาส์ในกล้อง
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ตรวจสอบว่า Ray โดน object ที่มี Collider หรือไม่
            if (Physics.Raycast(ray, out hit))
            {
                // ตรวจสอบว่าคลิก object ที่เรากำหนดไว้หรือไม่
                if (hit.collider.gameObject == targetObject)
                {
                    // แสดง Canvas
                    targetCanvas.gameObject.SetActive(true);
                }
            }
        }
    }
}
