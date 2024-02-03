using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Sample
{
    public class NotifyToUser: INotifyObserver
    {
        public void ThongBao()
        {
            Debug.Log("from Admin: ban da tinh toan thanh cong");
        }
    }
}