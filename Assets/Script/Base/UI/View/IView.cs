namespace Base.UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IView 
    {
        /// <summary>
        /// View��Ψһ��ʶ
        /// </summary>
        int Id { get; }

        /// <summary>
        /// View����, һ����View���ڵ�GameObject����
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// View��ǣ���ǰView������ȫ���ƣ�ֻ������
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// ��ת��View���Զ������, �����ڵ�Presenter����
        /// </summary>
        object ExtraData { get; set; }

        /// <summary>
        /// View����GameObject�ĸ��ڵ��Transform
        /// </summary>
        Transform Parent { get; }

        /// <summary>
        /// View������Transform���
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// View����GameObject
        /// </summary>
        GameObject GameObject { get; }

        /// <summary>
        /// ��ʶ��ǰView�Ŀɼ���
        /// ��ʹView����GameObject��Active����ΪTrue, ����͸���Ȼ�������ֵΪ0��ҲӦ�ñ��Ϊ���ɼ�
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// ��ǰView�Ƿ�������
        /// </summary>
        bool IsPrepared { get; set; }

        /// <summary>
        /// ��ǰView�Ƿ�����, GameObjectΪ��ʱΪ������״̬
        /// </summary>
        bool IsDestroyed { get; }

        /// <summary>
        /// ��ʶ��ǰView�Ƿ�ɽ���
        /// </summary>
        bool Interactable { get; set; }

        /// <summary>
        /// ��ʶ��ǰView�Ķ����Ƿ񻺴�
        /// </summary>
        bool IsCache { get; set; }

        /// <summary>
        /// View������ɲ�����ViewModel֮����ã��˷���������View�ڲ��첽�����Լ����ݰ�
        /// ע��: ע��: ��ʱ��View���ڲ��ɼ�״̬, �������ڳ�ʼ������
        /// </summary>
        public void Prepare(){}

        /// <summary>
        /// ���붯����ʼ, View��ʼ�ɼ�
        /// ������л�����: ���붯����ʼ�󱻵���
        /// ������л�����: View��Show�������ú󱻵���
        /// </summary>
        public void OnAppearing();

        /// <summary>
        /// ���붯������, View������ȫ�ɼ�״̬�󱻵���
        /// </summary>
        public void OnAppeared();

        /// <summary>
        /// Viewÿ�λָ�ʱ������(������ɶ������֮��)
        /// </summary>
        public void OnResume();

        /// <summary>
        /// Viewÿ����ͣʱ������(��ջ�µĽ���ʱ)
        /// </summary>
        public void OnPause();

        /// <summary>
        /// �˳����ɶ�����ʼ, View��ʼ���ɼ�
        /// ������л�����: View��OnPause�������������˳�������ʼ�󱻵���
        /// ������л�����: View��OnPause���������ñ�����
        /// </summary>
        public void OnDisappearing();

        /// <summary>
        /// �˳����ɶ�������, View��ȫ���ɼ�
        /// ������л�����: �˳�������ɺ󱻵���
        /// ������л�����: View��Hide�������ú󱻵���
        /// </summary>
        public void OnDisappeared();

        /// <summary>
        /// View������ǰ���������, ������һ��
        /// </summary>
        public void Dispose();

        /// <summary>
        /// ��ʾ
        /// </summary>
        public void Show();

        /// <summary>
        /// ����
        /// </summary>
        public void Hide();

        /// <summary>
        /// ˢ��View
        /// </summary>
        public void Refresh();

        /// <summary>
        /// ���ٵ�ǰView
        /// </summary>
        public void DestorySelf();

        /// <summary>
        /// �����ӽڵ�
        /// </summary>
        public Transform FindTransform(string nodeName);

        /// <summary>
        /// ���ð󶨵�ViewModel
        /// </summary>
        /// <param name="dataContext"></param>
        public void SetDataContext(object dataContext);
    }
}
