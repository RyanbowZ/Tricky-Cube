using UnityEngine;
using UnityEngine.UI;

namespace y7play
{
    /// <summary>
    /// �Զ����ͼ���
    /// </summary>
    public class MapImage : Image
    {
        /// <summary>
        /// ��д���߼�ⷽ��
        /// </summary>
        /// <param name="screenPoint"></param>
        /// <param name="eventCamera"></param>
        /// <returns></returns>
        public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
        {
            return GetComponent<PolygonCollider2D>().OverlapPoint(screenPoint);
        }
    }
}
