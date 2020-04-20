using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;
using TMPro;

 public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     public TMPro.TextMeshProUGUI theText;
 
     public void OnPointerEnter(PointerEventData eventData)
     {
         theText.fontStyle = FontStyles.Italic;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         theText.fontStyle = FontStyles.Normal;
     }
 }
