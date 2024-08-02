using System;
using System.Collections.Generic;
using System.Text;

namespace AllTest.数据结构
{
    class Stack
    {
        /* 使用迭代模拟递归 */
        int ForLoopRecur(int n)
        {
            // 使用一个显式的栈来模拟系统调用栈
            Stack<int> stack = new Stack<int>();
            int res = 0;
            // 递：递归调用
            for (int i = n; i > 0; i--)
            {
                // 通过“入栈操作”模拟“递”
                stack.Push(i);
            }
            // 归：返回结果
            while (stack.Count > 0)
            {
                // 通过“出栈操作”模拟“归”
                res += stack.Pop();
            }
            // res = 1+2+3+...+n
            return res;
        }
    }
}
