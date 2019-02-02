using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class dragitem : MonoBehaviour, IDragHandler,IEndDragHandler,IPointerDownHandler,IPointerUpHandler
{
    Animator anim;
    public GameObject square, circle, triangle, pentagon,canvas,a,b,c,d;
    float t = 3;
    Vector3 curpos;
   public float pointerdowntimer,holdtime=2;
    bool pointerdown,enable;
   public RectTransform panel;
   //public UnityEvent OnlongClick;

  // public SpriteRenderer renderer;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        panel = transform as RectTransform;
        //transform.localPosition = pos.anchoredPosition;
        curpos = transform.localPosition;
        //renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerdown){

            pointerdowntimer += Time.deltaTime;
            if(pointerdowntimer>=1){
                Debug.Log(pointerdowntimer);
            }
            Debug.Log(pointerdowntimer);
            if(pointerdowntimer>=holdtime)
            {
                enable = true;
                //Debug.Log("enabled");
                anim.SetTrigger("editable");
            }
            else{
                enable = false;
            }
            
        }
        else
        {
            if(!enable)
            {

                //reset();
               
                //Debug.Log("disabled");

            }
            reset();

        }
        }


    public void OnPointerUp(PointerEventData eventData)
    {
        reset();
        if (this.gameObject.name == "b")
        {
          //  FindObjectOfType<dropitem>().dropped(true); FindObjectOfType<dropitem>().dropped(true); FindObjectOfType<dropitem>().dropped(true);
            //Debug.Log("sending data to drop bool");
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerdown = true;
       
    }
    void reset(){
        FindObjectOfType<dropitem>().dropped(false);
        pointerdown = false;
        pointerdowntimer = 0;
        anim.SetTrigger("normal");
        anim.SetTrigger("normal");
        anim.SetTrigger("normal");

    }
    public void OnDrag(PointerEventData eventData)
    { if(enable){
        
            FindObjectOfType<dropitem>().dropped(false);
#if UNITY_ANDROID
        transform.position = Input.GetTouch(0).position;
#elif UNITY_IOS
        transform.position = Input.GetTouch(0).position;
    
#elif UNITY_STANDALONE
            this.transform.position = Input.mousePosition;
#endif
        }
    }
    public void OnEndDrag(PointerEventData eventData){
        // transform.localPosition = Vector3.zero;

        FindObjectOfType<dropitem>().dropped(true);

        if(transform.localPosition == panel.position )
        {
            Debug.Log("inpanel");
        }else
        {
            transform.localPosition = Vector3.Lerp(curpos * Time.deltaTime, Vector3.zero * Time.deltaTime, 0.01f);
        }
        FindObjectOfType<dropitem>().dropped(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Square"){
            this.transform.parent = square.transform;
            if (this.gameObject.name == "b")
            {
                changecolor();
            }
        }
        if (collision.tag == "circle")
        {

            this.transform.parent = circle.transform;


        }
        if (collision.tag == "pentagon")
        {
            if (this.gameObject.name == "b")
            {
                changecolor();
            }
            this.transform.parent = pentagon.transform;
        }
        if (collision.tag == "triangle")
        {
            if (this.gameObject.name == "b")
            {
                changecolor();
            }
            this.transform.parent = triangle.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Square")
        {
            if(this.gameObject.name=="a"){
                this.transform.parent = a.transform;
            }
            if (this.gameObject.name == "b")
            {
                this.transform.parent = b.transform;
            }
            if (this.gameObject.name == "c")
            {
                this.transform.parent = c.transform;
            }
            if (this.gameObject.name == "d")
            {
                this.transform.parent = d.transform;
            }

        }
        if (collision.tag == "circle")
        {
            if (this.gameObject.name == "a")
            {
                this.transform.parent = a.transform;
            }
            if (this.gameObject.name == "b")
            {
                this.transform.parent = b.transform;
            }
            if (this.gameObject.name == "c")
            {
                this.transform.parent = c.transform;
            }
            if (this.gameObject.name == "d")
            {
                this.transform.parent = d.transform;
            }
        }
        if (collision.tag == "pentagon")
        {
            if (this.gameObject.name == "a")
            {
                this.transform.parent = a.transform;
            }
            if (this.gameObject.name == "b")
            {
                this.transform.parent = b.transform;
            }
            if (this.gameObject.name == "c")
            {
                this.transform.parent = c.transform;
            }
            if (this.gameObject.name == "d")
            {
                this.transform.parent = d.transform;
            }
        }
        if (collision.tag == "triangle")
        {
            if (this.gameObject.name == "a")
            {
                this.transform.parent = a.transform;
            }
            if (this.gameObject.name == "b")
            {
                this.transform.parent = b.transform;
            }
            if (this.gameObject.name == "c")
            {
                this.transform.parent = c.transform;
            }
            if (this.gameObject.name == "d")
            {
                this.transform.parent = d.transform;
            }
        }
    }

  void  changecolor(){
        GetComponent<Image>().color = new Color(1f, 0, 0, .7f);
        StartCoroutine(waitfor3sec());
    }
    IEnumerator waitfor3sec(){
        yield return new WaitForSecondsRealtime(3f);
        GetComponent<Image>().color = new Color(1f, 1, 1, 1);
    }
}
