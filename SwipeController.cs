// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class SwipeController : MonoBehaviour, IEndDragHandler
// {
//     [SerializeField] int maxPage;
//     int currentPage;
//     Vector3 targetPos;
//     [SerializeField] Vector3 pageStep;
//     [SerializeField] RectTransform weaponPagesRect;
//     [SerializeField] float tweenTime;
//     [SerializeField] LeanTweenType tweenType;
//     float dragThreshould;

//     private void Awake()
//     {
//         currentPage = 1;
//         targetPos = weaponPagesRect.localPosition;
//         dragThreshould = Screen.width / 15;
//     }

//     public void Next()
//     {
//         if(currentPage < maxPage)
//         {
//             currentPage++;
//             targetPos+=pageStep;
//             MovePage();
//         }
//     }

//     public void Previous()
//     {
//         if(currentPage > 1)
//         {
//             currentPage--;
//             targetPos = targetPos - pageStep;
//             MovePage();
//         }
//     }

//     public void MovePage()
//     {
//         weaponPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         if(Mathf.Abs(eventData.position.x - eventData.pressPosition.x)>dragThreshould)
//         {
//             if(eventData.position.x > eventData.pressPosition.x) Previous();
//             else Next();
//         }
//         else
//         {
//             MovePage();
//         }
//     }
// }




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;

// public class SwipeController : MonoBehaviour, IEndDragHandler
// {
//     [SerializeField] int maxPage;
//     int currentPage;
//     Vector3 targetPos;
//     [SerializeField] Vector3 pageStep;
//     [SerializeField] RectTransform weaponPagesRect;
//     [SerializeField] float tweenTime;
//     [SerializeField] LeanTweenType tweenType;
//     float dragThreshould;

//     // Add references to your weapon GameObjects or scripts
//     public GameObject[] weapons;

//     private void Awake()
//     {
//         currentPage = 1;
//         targetPos = weaponPagesRect.localPosition;
//         dragThreshould = Screen.width / 15;

//         // Ensure only the first weapon is active at the start
//         ActivateWeapon(currentPage - 1); // currentPage is 1-based index
//     }

//     public void Next()
//     {
//         if (currentPage < maxPage)
//         {
//             currentPage++;
//             targetPos += pageStep;
//             MovePage();
//             ActivateWeapon(currentPage - 1); // Activate the selected weapon (0-based index)
//         }
//     }

//     public void Previous()
//     {
//         if (currentPage > 1)
//         {
//             currentPage--;
//             targetPos -= pageStep;
//             MovePage();
//             ActivateWeapon(currentPage - 1); // Activate the selected weapon (0-based index)
//         }
//     }

//     public void MovePage()
//     {
//         weaponPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshould)
//         {
//             if (eventData.position.x > eventData.pressPosition.x) Previous();
//             else Next();
//         }
//         else
//         {
//             MovePage();
//         }
//     }

//     // Method to activate the selected weapon and deactivate others
//     void ActivateWeapon(int weaponIndex)
//     {
//         for (int i = 0; i < weapons.Length; i++)
//         {
//             if (i == weaponIndex)
//             {
//                 weapons[i].SetActive(true);
//             }
//             else
//             {
//                 weapons[i].SetActive(false);
//             }
//         }
//     }
// }




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IEndDragHandler
{
    [SerializeField] int maxPage;
    int currentPage;
    Vector3 targetPos;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform weaponPagesRect;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    float dragThreshold;

    // Add references to your weapon GameObjects or scripts
    public GameObject[] weapons;

    private void Awake()
    {
        currentPage = 1;
        targetPos = weaponPagesRect.localPosition;
        dragThreshold = Screen.width / 15;

        // Ensure only the first weapon is active at the start
        ActivateWeapon(currentPage - 1); // currentPage is 1-based index
    }

    public void Next()
    {
        currentPage++;
        if (currentPage > maxPage)
        {
            currentPage = 1;
            targetPos -= pageStep * (maxPage - 1);
        }
        else
        {
            targetPos += pageStep;
        }
        MovePage();
        ActivateWeapon(currentPage - 1); // Activate the selected weapon (0-based index)
    }

    public void Previous()
    {
        currentPage--;
        if (currentPage < 1)
        {
            currentPage = maxPage;
            targetPos += pageStep * (maxPage - 1);
        }
        else
        {
            targetPos -= pageStep;
        }
        MovePage();
        ActivateWeapon(currentPage - 1); // Activate the selected weapon (0-based index)
    }

    public void MovePage()
    {
        weaponPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > dragThreshold)
        {
            if (eventData.position.x > eventData.pressPosition.x) Previous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }

    // Method to activate the selected weapon and deactivate others
    void ActivateWeapon(int weaponIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == weaponIndex)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}