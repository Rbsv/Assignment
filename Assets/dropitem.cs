using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class dropitem : MonoBehaviour, IDropHandler
{
    bool droppeditem=false;
    public GameObject a, b, c, d;
   /* private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "a" )
        { if(droppeditem)
            a.SetActive(true);
        }
        if(other.tag =="b" && droppeditem)
        {
            if (droppeditem)
                b.SetActive(true);
        }
        if (other.tag == "c" && droppeditem)
        {
            if (droppeditem)
                c.SetActive(true);
        }
        if (other.tag == "d" && droppeditem)
        {
            if (droppeditem)
                d.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "a" && droppeditem)
        {
            if (droppeditem)
                a.SetActive(false);
        }
        if (collision.tag == "b" && droppeditem)
        {
            if (droppeditem)
                b.SetActive(false);
        }
        if (collision.tag == "c" && droppeditem)
        {
            if (droppeditem)
                c.SetActive(false);
        }
        if (collision.tag == "d" && droppeditem)
        {
            if (droppeditem)
                d.SetActive(false);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "a" )
        {
            a.SetActive(false);
        }
        if (collision.tag == "b" )
        {
            b.SetActive(false);
        }
        if (collision.tag == "c" )
        {
            c.SetActive(false);
        }
        if (collision.tag == "d" )
        {
            d.SetActive(false);
        }
    }*/
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if(this.gameObject.name=="circle"){
          //  Debug.Log("this is Triangle");
            if(this.transform.Find("b")&&droppeditem){
//                Debug.Log("found 'B'");
                if (droppeditem==true)
                    //SceneManager.LoadScene("main2");
                SceneManager.LoadSceneAsync("main2");
                SceneManager.LoadSceneAsync("main2");
                Debug.Log("changescene =============================");

            }
        }

    }
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform panel = transform as RectTransform;

#if UNITY_STANDALONE
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.mousePosition))
        {
            Debug.Log("dropitem"); 
        }else
        {

        }

        #elif UNITY_ANDROID
         if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.GetTouch(0).position))
        {

        }
#elif UNITY_IOS
        if (!RectTransformUtility.RectangleContainsScreenPoint(panel, Input.GetTouch(0).position))
        {

        }
#endif
    }
        public void dropped(bool drop){
        if (drop == true)
        {
            droppeditem = drop;
            StartCoroutine(reset());
        }
        
//        Debug.Log(droppeditem);
        }
        IEnumerator reset(){
        yield return new WaitForSeconds(2);
        droppeditem = false;
        }
}
