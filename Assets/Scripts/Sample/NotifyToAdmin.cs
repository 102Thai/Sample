using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Sample
{
    public class NotifyToAdmin : MonoBehaviour
    {
        [SerializeField] TinhToan TinhToan;

        private void OnValidate()
        {
            TinhToan = GetComponent<TinhToan>();
        }

        private void Start()
        {
            TinhToan.onUserUserApp += Notify;
        }

        void Notify(User user,string tenPhepTinh)
        {
            Debug.Log($"to Admin: {user.name} da su dung ung dung va thuc hien phep {tenPhepTinh}");
        }
    }
}