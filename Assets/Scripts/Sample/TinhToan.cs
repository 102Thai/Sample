using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinhToan : MonoBehaviour
{
    public event Action<User, string> onUserUserApp;// khi nguoi dung tinh toan xong
    [SerializeField] User user= new User();

    void Start()
    {
        float[] numbers= {1,2,3,4,5,6,7};
        Debug.Log("Ket qua la: "+Tong(numbers,ThongBao));
    }

    void ThongBao()
    {
        Debug.Log("Da tinh toan thanh cong");
    }

    float Tong(float[] numbers,Action callback)
    {
        float kq = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            kq += numbers[i];
        }
        callback();
        onUserUserApp?.Invoke(user,"Tinh Tong");
        return kq;
    }

    float Tich(float[] numbers, Action callback)
    {
        float kq = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            kq *= numbers[i];
        }
        callback();
        onUserUserApp?.Invoke(user, "Tinh Tich");
        return kq;
    }
}

public class User
{
    public string name = "Thai";
}

