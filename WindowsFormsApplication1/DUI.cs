using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class DUI
    {
        public static double[] a=new double[100];
        public static int length;  //数组长度
        public static int countnum;//控制分步显示的计数变量
        public static double duiding;//堆顶元素
        public static bool sign;//是否分步显示标志
        public static double[] a_temp = new double[100];

        public static void rukou()
        {
            for (int i = (DUI.length / 2) - 1; i >= 0; i--)
            {
                Rebulid(i, DUI.length);
            }  // 建立最小堆。
            for (int p = 0; p <= DUI.length - 1; p++)
                a_temp[p] = a[p]; 
            if(countnum<=DUI.length-2||DUI.sign==false)
                DSort();//开始堆排序
        }

        //堆排序函数 每次循环 重新建堆  堆顶元素和堆末元素交换，堆元素长度-1 实现出堆 
        private static void DSort()
        {
            int counter=0;
            if (DUI.sign == true)
                counter = countnum;
            for (int i = DUI.length-1 ; i > counter; i--)
            {
                for (int p = 0; p <=DUI.length - 1; p++)
                    a_temp[p] = a[p]; 
                double temp;
                temp = a[0];
                a[0] = a[i];        //堆顶元素和堆末元素交换
                a[i] = temp;        //i=length-1：堆顶元素出堆  
                DUI.duiding = temp; //找出堆顶元素 
                Rebulid(0,i);// 将更新的堆调整为最小堆                
            }
        }

      
        //通过递归每次将需要调整的数传向下一层
        private static void Rebulid(int i, int dui_len)
        {
            int left = (2 * i) + 1; // 左结点。  
            int right = 2 * (i + 1); // 右结点。  
            int jmin = i; // 存放可能需要调整的子节点数组编号  

            // 和左右字结点比较 如不满足堆性质则将左右子节点小数组编号的那个存入jmin  
            if (left < dui_len && a[left] < a[jmin])
            {
                jmin = left;
            }
            if (right < dui_len && a[right] < a[jmin])
            {
                jmin = right;
            }

            // 如有子结点小于父节点交换，小的元素变为父节点 并更新调整元素的子树堆  
            if (i != jmin)
            {
                double temp;
                temp = a[i];
                a[i] = a[jmin];
                a[jmin] = temp;
                Rebulid(jmin, dui_len);
            }
        }
    }    
}
