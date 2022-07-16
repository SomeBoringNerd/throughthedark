using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fragsurf.Movement;
using UnityEngine.UI;
using TMPro;
public class NoteBookScript : MonoBehaviour
{
    public PlayerAiming playerCamera;
    public SurfCharacter playerController;
    public InteractableScript interactable;

    public GameObject book_parent;

    public TMP_Text indication;

    public InputField pageText;

    public string[] note_pages;

    public int page;

    // Start is called before the first frame update
    void Start()
    {
        book_parent.SetActive(false);
        page = GameGlobal.LastOpenedPage;


        note_pages = new string[50];

        for(int i = 0; i < 50; i++)
        {
            note_pages[i] = GameGlobal.getPage(i);
        }

        pageText.text = (note_pages[page]);
    }

    // Update is called once per frame
    void Update()
    {
        //kill switch because Unity is fucking dumb 
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F5))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
#endif

        if (!interactable.isUsable) return;
        
        if (Input.GetKeyDown(KeyCode.E) && !book_parent.activeSelf)
        {
            book_parent.SetActive(true);
            playerCamera.enabled = false;
            playerController.enabled = false;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;


        }

        if (book_parent.activeSelf)
        {
            int tmp = page + 1;
            indication.text = "page " + tmp + " / " + note_pages.Length;
        }
    }

    public void CloseBook()
    {
        GameGlobal.LastOpenedPage = page;
        note_pages[page] = pageText.text;

        int i = 0;

        foreach(string page in note_pages)
        {
            GameGlobal.setPage(i, page);
            i++;
        }

        book_parent.SetActive(false);
        playerCamera.enabled = true;
        playerController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void NextPage()
    {
        note_pages[page] = pageText.text;
        Debug.Log("set text \"" + pageText.text + "\" as page" + (page + 1) + " under profile " + GameGlobal.Profile);

        if (page != note_pages.Length - 1)
        {
            page++;
        }
        else
        {
            page = 0;
        }

        pageText.text = (note_pages[page]);
    }

    public void PreviousPage()
    {
        note_pages[page] = pageText.text;

        Debug.Log("set text \"" + pageText.text + "\" as page" + page + " under profile " + GameGlobal.Profile);

        if (page != 0)
        {
            page--;
        }
        else
        {
            page = note_pages.Length - 1;
        }
        pageText.text = (note_pages[page]);
    }

}
