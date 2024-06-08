// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class SwipeGun : MonoBehaviour
// {
//     public GameObject Scrollbar;
//     float ScrollPos = 0;
//     float[] pos;

//     void Update()
//     {
//         pos = new float[transform.childCount];
//         float distance = 1f / (pos.Length - 1f);
//         for(int i = 0; i<pos.Length; i++)
//         {
//             pos [i] = distance * i;
//         }
//         if (Input.GetMouseButton (0)){
//             ScrollPos = Scrollbar.GetComponent<Scrollbar>().value;
//         }else{
//             for(int i = 0; i<pos.Length; i++){
//                 if (ScrollPos < pos [i] + (distance / 2) && ScrollPos > pos [i] - (distance / 2)){
//                     Scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(Scrollbar.GetComponent<Scrollbar>().value, pos [i], 0.1f);
//                 }
//             }
//         }
//     }
// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteSwipeGunScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform viewPortTransform;
    public RectTransform contentPanelTransform;
    public HorizontalLayoutGroup HLG;

    public RectTransform[] itemList;
    private Vector2 oldVelocity;
    private bool isUpdated;
    private float scrollPos = 0;
    private float[] pos;

    void Start()
    {
        isUpdated = false;
        oldVelocity = Vector2.zero;

        // Setup infinite scroll
        int itemsToAdd = Mathf.CeilToInt(viewPortTransform.rect.width / (itemList[0].rect.width + HLG.spacing));
        for (int i = 0; i < itemsToAdd; i++)
        {
            RectTransform RT = Instantiate(itemList[i % itemList.Length], contentPanelTransform);
            RT.SetAsLastSibling();
        }
        for (int i = 0; i < itemsToAdd; i++)
        {
            int num = itemList.Length - i - 1;
            while (num < 0)
            {
                num += itemList.Length;
            }
            RectTransform RT = Instantiate(itemList[num], contentPanelTransform);
            RT.SetAsFirstSibling();
        }
        contentPanelTransform.localPosition = new Vector3(
            (0 - (itemList[0].rect.width + HLG.spacing) * itemsToAdd),
            contentPanelTransform.localPosition.y,
            contentPanelTransform.localPosition.z
        );
    }

    void Update()
    {
        // Infinite scrolling update
        if (isUpdated)
        {
            isUpdated = false;
            scrollRect.velocity = oldVelocity;
        }
        if (contentPanelTransform.localPosition.x > 0)
        {
            Canvas.ForceUpdateCanvases();
            oldVelocity = scrollRect.velocity;
            contentPanelTransform.localPosition -= new Vector3(itemList.Length * (itemList[0].rect.width + HLG.spacing), 0, 0);
            isUpdated = true;
        }
        if (contentPanelTransform.localPosition.x < 0 - (itemList.Length * (itemList[0].rect.width + HLG.spacing)))
        {
            Canvas.ForceUpdateCanvases();
            oldVelocity = scrollRect.velocity;
            contentPanelTransform.localPosition += new Vector3(itemList.Length * (itemList[0].rect.width + HLG.spacing), 0, 0);
            isUpdated = true;
        }

        // Swipe detection and snapping update
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollRect.horizontalNormalizedPosition;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, pos[i], 0.1f);
                }
            }
        }
    }
}
