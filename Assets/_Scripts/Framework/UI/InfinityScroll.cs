using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// <para> The default ScrollView is laggy when there is many children. Use Infinity Scroll to solve this problem</para>
/// </summary>
public class InfinityScroll : MonoBehaviour
{

    public int maxChild;
    public int maxHei;
    public int maxWid;
    public ScrollRect scrollView;
    public RectTransform container;
    public RectTransform child;
    public List<object> childInfo;
    int currentIndex;
    void Start()
    {

        maxChild = maxHei * maxWid;
        for(int i = 0; i < maxChild; ++i){
            Transform newChild = Instantiate(child, container);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollView.vertical){
            if (container.GetChild(maxChild-1).GetComponent<RectTransform>().rect.yMin >= container.rect.yMin){
                RectTransform firstChild = container.GetChild(0).GetComponent<RectTransform>();
                firstChild.SetAsLastSibling();
                firstChild.GetComponent<IRecycleableSlot>().SetItem(childInfo[currentIndex + 1]);
            }
        }
        else if (scrollView.horizontal){
            
        }
    }
}
