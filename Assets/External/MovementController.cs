using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Animator animator;
    private int IsEstasMortHash;
    private int IsTalkHash;
    private int IsShhHash;
    private int IsGallinaHash;
    private int IsThanksHash;
    public InputController _input;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        IsEstasMortHash = Animator.StringToHash("EstasMort");
        IsThanksHash = Animator.StringToHash("Thanks");
        IsGallinaHash = Animator.StringToHash("Gallina");
        IsShhHash = Animator.StringToHash("Shh");
        IsTalkHash = Animator.StringToHash("Talk");
    }

    public void EstasMort()
    {
        bool IsEstasMort = animator.GetBool(IsEstasMortHash);

        animator.SetBool(IsEstasMortHash, true);
        Debug.Log("Funciona");
        Invoke("EstasMortFalse", 2.0f);
    }
    public void Talk()
    {
        bool IsTalk = animator.GetBool(IsTalkHash);

        animator.SetBool(IsTalkHash, true);
        Debug.Log("Funciona");
        Invoke("TalkFalse", 4.0f);
    }
    public void Shh()
    {
        bool Shh = animator.GetBool(IsShhHash);

        animator.SetBool(IsShhHash, true);
        Debug.Log("Funciona");
        Invoke("ShhFalse", 5.0f);
    }
    public void Gallina()
    {
        bool Shh = animator.GetBool(IsGallinaHash);

        animator.SetBool(IsGallinaHash, true);
        Debug.Log("Funciona");
        Invoke("GallinaFalse", 5.0f);
    }
    public void Thanks()
    {
        bool Shh = animator.GetBool(IsThanksHash);

        animator.SetBool(IsThanksHash, true);
        Debug.Log("Funciona");
        Invoke("ThanksFalse", 5.0f);
    }
    public void ThanksFalse()
    {
        animator.SetBool(IsThanksHash, false);
    }
    public void EstasMortFalse()
    {
        animator.SetBool(IsEstasMortHash, false);
    }
    public void TalkFalse()
    {
        animator.SetBool(IsTalkHash, false);
    }

    public void Flee()
    {
        transform.Translate(new Vector3(0, 3, 0));
    }

    public void Attack()
    {
        transform.Translate(new Vector3(-3, 0, 0));
    }
    public void ShhFalse()
    {
        animator.SetBool(IsShhHash, false);
    }
    public void GallinaFalse()
    {
        animator.SetBool(IsGallinaHash, false);
    }
}
