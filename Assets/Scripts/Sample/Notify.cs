using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Sample
{
    public class Notify : MonoBehaviour
    {
        [SerializeField] TinhToan TinhToan;

        private void OnValidate()
        {
            TinhToan = GetComponent<TinhToan>();
        }

        private void Start()
        {
            TinhToan.onUserUserApp += NotifyToAdmin;
        }

        void NotifyToAdmin(User user,string tenPhepTinh)
        {
            Debug.Log($"{user.name} da su dung ung dung va thuc hien phep tinh{tenPhepTinh}");
        }

    }
}