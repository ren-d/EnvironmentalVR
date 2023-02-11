using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
public class TrashCan : MonoBehaviour
{
    public Shrink[] deadFoliage;
    public GameObject progressBar;
    public static int trashBinned = 0;

    public static int winCounter = 10;
    // Start is called before the first frame update
    void Start()
    {
        Shrink[] treesFound = FindObjectsOfType<Shrink>();
        deadFoliage = treesFound;
        //foreach (Shrink foliage in deadFoliage)
        //{
            //foliage.gameObject.SetActive(false);
        //}
        progressBar.GetComponent<RectTransform>().localScale = new Vector3(0,1,1);
        winCounter = deadFoliage.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable interactable;
        if (other.TryGetComponent<XRGrabInteractable>(out interactable))
        {
            if (interactable == null)
                return;

            if (other.tag == "Respawn")
            {
                trashBinned = 0;

                SceneManager.LoadScene(0);
            }
            Destroy(other.gameObject);
            trashBinned++;
            if (trashBinned > deadFoliage.Length)
                return;
            UpdateProgressBar(trashBinned);
            EnableTree(trashBinned);
        }
    }

    private void EnableTree(int treeNum)
    {



        deadFoliage[treeNum].start = true;
        if (trashBinned >= winCounter)
        {
            EndGame();
        }
    }
    private void UpdateProgressBar(int treeNum)
    {
        float a = treeNum;
        float b = winCounter;
        progressBar.GetComponent<RectTransform>().localScale = new Vector3(a/b,1.0f,1.0f);
    }

    public void EndGame()
    {

    }
}
