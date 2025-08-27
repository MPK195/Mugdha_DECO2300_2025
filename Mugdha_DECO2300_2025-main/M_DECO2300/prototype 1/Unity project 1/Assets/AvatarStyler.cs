using UnityEngine;

public class AvatarStyler : MonoBehaviour
{
    public Renderer target; // drag the Avatar's MeshRenderer here
    public Material jacket, tee, jeans;

    public void WearJacket() { Apply(jacket); }
    public void WearTee()    { Apply(tee); }
    public void WearJeans()  { Apply(jeans); }

    void Apply(Material m)
    {
        if (target == null || m == null) return;
        var mats = target.sharedMaterials;
        for (int i = 0; i < mats.Length; i++) mats[i] = m;
        target.sharedMaterials = mats;
    }
}
