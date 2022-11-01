using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Tree
    {
        public class TreeNode
        {
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public int Data { get; set; }
        }

        public static void InOrder(TreeNode root)
        {
            if(root != null)
            {
                InOrder(root.Left);
                System.Diagnostics.Debug.WriteLine(root.Data);
                InOrder(root.Right);
            }
        }

        public static void PreOrder(TreeNode root)
        {
            if(root != null)
            {
                System.Diagnostics.Debug.WriteLine(root.Data);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
        }

        public static void PostOrder(TreeNode root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                System.Diagnostics.Debug.WriteLine(root.Data);
            }
        }
    }
}
