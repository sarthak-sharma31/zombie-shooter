using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    public ScrollRect ScrollRect;
    public RectTransform viewPortTransform;
    public RectTransform contentPanelTransform;
    public HorizontalLayoutGroup HLG;
    public RectTransform[] ItemList;
    public float SnapForce = 10f;

    private Vector2 OldVelocity;
    private bool isUpdated;
    private bool isSnapped = true;
    private float snapSpeed;
    private int previousItemIndex;

    void Start()
    {
        isUpdated = false;
        OldVelocity = Vector2.zero;
        snapSpeed = 0f;

        // Calculate the number of items to add
        int ItemsToAdd = Mathf.CeilToInt(viewPortTransform.rect.width / (ItemList[0].rect.width + HLG.spacing));

        // Add items to the end
        for (int i = 0; i < ItemsToAdd; i++)
        {
            RectTransform RT = Instantiate(ItemList[i % ItemList.Length], contentPanelTransform);
            RT.SetAsLastSibling();
        }

        // Add items to the beginning
        for (int i = 0; i < ItemsToAdd; i++)
        {
            int num = ItemList.Length - i - 1;
            while (num < 0)
            {
                num += ItemList.Length;
            }
            RectTransform RT = Instantiate(ItemList[num], contentPanelTransform);
            RT.SetAsFirstSibling();
        }

        // Adjust the initial position of the content panel
        contentPanelTransform.localPosition = new Vector3(0 - (ItemList[0].rect.width + HLG.spacing) * ItemsToAdd,
        contentPanelTransform.localPosition.y,
        contentPanelTransform.localPosition.z);
    }

    void Update()
    {
        if (isUpdated)
        {
            isUpdated = false;
            ScrollRect.velocity = OldVelocity;
        }

        // Infinite scrolling logic
        if (contentPanelTransform.localPosition.x > 0)
        {
            Canvas.ForceUpdateCanvases();
            OldVelocity = ScrollRect.velocity;
            contentPanelTransform.localPosition -= new Vector3(ItemList.Length * (ItemList[0].rect.width + HLG.spacing), 0, 0);
            isUpdated = true;
        }
        if (contentPanelTransform.localPosition.x < 0 - (ItemList.Length * (ItemList[0].rect.width + HLG.spacing)))
        {
            Canvas.ForceUpdateCanvases();
            OldVelocity = ScrollRect.velocity;
            contentPanelTransform.localPosition += new Vector3(ItemList.Length * (ItemList[0].rect.width + HLG.spacing), 0, 0);
            isUpdated = true;
        }

        // Snapping logic
        int currentItem = Mathf.RoundToInt(-contentPanelTransform.localPosition.x / (ItemList[0].rect.width + HLG.spacing));
        
        if (ScrollRect.velocity.magnitude < 200 && !isSnapped)
        {
            SnapToItem(currentItem);
        }

        if (ScrollRect.velocity.magnitude > 200)
        {
            isSnapped = false;
            snapSpeed = 0f;
        }
    }

    private void SnapToItem(int currentItem)
    {
        snapSpeed += SnapForce;
        // snapSpeed += SnapForce * Time.deltaTime;
        float targetPositionX = -currentItem * (ItemList[0].rect.width + HLG.spacing);
        contentPanelTransform.localPosition = new Vector3(Mathf.MoveTowards(contentPanelTransform.localPosition.x, targetPositionX, snapSpeed), contentPanelTransform.localPosition.y, contentPanelTransform.localPosition.z);

        if (Mathf.Abs(contentPanelTransform.localPosition.x - targetPositionX) < 0.01f)
        {
            contentPanelTransform.localPosition = new Vector3(targetPositionX, contentPanelTransform.localPosition.y, contentPanelTransform.localPosition.z);
            ScrollRect.velocity = Vector2.zero;
            isSnapped = true;
            snapSpeed = 0f;
        }
    }
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class InfiniteScroll : MonoBehaviour
// {
//     public ScrollRect ScrollRect;
//     public RectTransform viewPortTransform;
//     public RectTransform contentPanelTransform;
//     public HorizontalLayoutGroup HLG;

//     public RectTransform[] ItemList;

//     Vector2 OldVelocity;
//     bool isUpdated;
    
//     void Start()
//     {
//         isUpdated = false;
//         OldVelocity = Vector2.zero;
//         int ItemsToAdd = Mathf.CeilToInt(viewPortTransform.rect.width / (ItemList[0].rect.width+HLG.spacing));
//         for(int i = 0; i < ItemsToAdd; i++){
//             RectTransform RT = Instantiate(ItemList[i%ItemList.Length], contentPanelTransform);
//             RT.SetAsLastSibling();
//         }
//         for(int i = 0; i < ItemsToAdd; i++){
//             int num = ItemList.Length - i - 1;
//             while(num < 0){
//                 num+=ItemList.Length;
//             }
//             RectTransform RT = Instantiate(ItemList[num], contentPanelTransform);
//             RT.SetAsFirstSibling();
//         }
//         contentPanelTransform.localPosition = new Vector3((0 - (ItemList[0].rect.width+HLG.spacing)*ItemsToAdd),
//         contentPanelTransform.localPosition.y,
//         contentPanelTransform.localPosition.z);
//     }

//     void Update()
//     {
//         if(isUpdated){
//             isUpdated = false;
//             ScrollRect.velocity = OldVelocity;
//         }
//         if(contentPanelTransform.localPosition.x > 0)
//         {
//             Canvas.ForceUpdateCanvases();
//             OldVelocity = ScrollRect.velocity;
//             contentPanelTransform.localPosition -= new Vector3(ItemList.Length*(ItemList[0].rect.width+HLG.spacing), 0,0);
//             isUpdated = true;
//         }
//         if(contentPanelTransform.localPosition.x < 0- (ItemList.Length * (ItemList[0].rect.width+HLG.spacing)))
//         {
//             Canvas.ForceUpdateCanvases();
//             OldVelocity = ScrollRect.velocity;
//             contentPanelTransform.localPosition += new Vector3(ItemList.Length*(ItemList[0].rect.width+HLG.spacing), 0,0);
//             isUpdated = true;
//         }
//     }
// }
