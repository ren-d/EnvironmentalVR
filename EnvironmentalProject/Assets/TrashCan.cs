using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
public class TrashCan : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject progressBar;
    public int trashBinned = 0;

    public const int winCounter = 10;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject tree in trees)
        {
            tree.SetActive(false);
        }
        progressBar.GetComponent<RectTransform>().localScale = new Vector3(0,1,1);
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
                SceneManager.LoadScene(0);
            }
            Destroy(other.gameObject);
            trashBinned++;
            UpdateProgressBar(trashBinned);
            EnableTree(trashBinned);
        }
    }

    private void EnableTree(int treeNum)
    {
        trees[treeNum].gameObject.SetActive(true);
        if (trashBinned >= winCounter)
        {
            EndGame();
        }
    }
    private void UpdateProgressBar(int treeNum)
    {
        progressBar.GetComponent<RectTransform>().localScale = new Vector3(treeNum/winCounter,1,1);
    }

    public void EndGame()
    {

    }
}
