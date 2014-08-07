using UnityEngine;
using System.Collections;

public class dragDrop : MonoBehaviour {

    RaycastHit2D hit;
    bool isGrabing = false;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        checkInputs();
        drag();
	}

    GameObject onDragMouse()
    {
            hit = Physics2D.Raycast(new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x,
            camera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if (hit.collider.gameObject.tag == "grappe")
            {
                Debug.Log("ok");
                isGrabing = true;
            }
            return (hit.collider.gameObject);
    }

    void checkInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onDragMouse();
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            isGrabing = false;
        }
    }

    void drag()
    {
        if(isGrabing)
        {
            Vector3 save = camera.ScreenToWorldPoint(Input.mousePosition);
            save.z = 0;
            onDragMouse().transform.position = save;
        }
    }
}
