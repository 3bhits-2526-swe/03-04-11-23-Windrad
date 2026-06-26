using UnityEngine;

public class ProfilUIclose : MonoBehaviour
{
    public GameObject profilUI;

    public void CloseProfilUI()
    {
        profilUI.SetActive(false);
    }
}
