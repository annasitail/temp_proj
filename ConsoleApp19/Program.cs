using System;

namespace ConsoleApp19
{
    class BinaryTree
    {
        public BinaryTreeNode root { get; set; }

        void DisplayNode(BinaryTreeNode node, string[,] matrix, int width, int level, int offset)
        {
            if (node == null)
                return;
            int center = (int)Math.Ceiling(width / Math.Pow(2, level)) + offset;
            matrix[level, center] = node.value;
            DisplayNode(node.left, matrix, width, level + 1, offset);
            DisplayNode(node.right, matrix, width, level + 1, center - 1);
        }

        public int GetLevelsAmount()
        {
            int count = 0
        }

        public void Display()
        {
            // hardcoded
            int level = 4;
            int width = (int)Math.Pow(2, level - 1) * 2 - 1;
            var matrix = new string[level + 1, width + 1];
            DisplayNode(root, matrix, width, 1, 0);
            for (int i = 1; i <= level; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    class BinaryTreeNode
    {
        public BinaryTreeNode parent { get; set; }
        public BinaryTreeNode left { get; set; }
        public BinaryTreeNode right { get; set; }
        public string value { get; set; }
    }

    class Program
    {
        public static bool IsBooleanValue(string value)
        {
            return value == "T" || value == "F";
        }

        public static int GetIndexOfClosedBracket(string expression, int index)
        {
            int count = 1;
            for (int i = index + 1; i < expression.Length; i++)
            {
                if (expression[i].ToString() == "(")
                {
                    count++;
                }
                else if (expression[i].ToString() == ")")
                {
                    count--;
                }
                if (count == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public static BinaryTreeNode ParseSubTree(string expression)
        {
            var binaryTree = new BinaryTree();
            BinaryTreeNode currentNode = null;
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsBooleanValue(expression[i].ToString()))
                {
                    var node = new BinaryTreeNode();
                    node.value = expression[i].ToString();
                    node.parent = currentNode;
                    if (binaryTree.root == null)
                    {
                        binaryTree.root = node;
                        currentNode = node;
                    }
                    else
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = node;
                        }
                        else
                        {
                            currentNode.right = node;
                        }

                        if (currentNode.value == "!" && currentNode.parent != null)
                        {
                            currentNode = currentNode.parent;
                        }
                    }
                }
                else
                {
                    if (expression[i].ToString() == "(")
                    {
                        var lastbracket = GetIndexOfClosedBracket(expression, i);
                        var node = ParseSubTree(expression.Substring(i + 1, lastbracket - i - 1));
                        if (currentNode == null)
                        {
                            binaryTree.root = node;
                            currentNode = node;
                        }
                        else if (currentNode.left == null)
                        {
                            currentNode.left = node;
                        }
                        else
                        {
                            currentNode.right = node;
                        }
                        i = lastbracket;
                    }
                    else if (expression[i].ToString() == "!")
                    {
                        var node = new BinaryTreeNode();
                        node.value = expression[i].ToString();
                        node.parent = currentNode;
                        if (currentNode == null)
                        {
                            binaryTree.root = node;
                            currentNode = node;
                        }
                        else if (currentNode.left == null)
                        {
                            currentNode.left = node;
                        }
                        else
                        {
                            currentNode.right = node;
                        }
                        currentNode = node;
                    }
                    else if (expression[i].ToString() != ")")
                    {
                        var parentNode = currentNode.parent;
                        if (parentNode == null)
                        {
                            parentNode = new BinaryTreeNode();
                            parentNode.left = currentNode;
                            parentNode.value = expression[i].ToString();
                            binaryTree.root = parentNode;
                        }
                        currentNode = parentNode;
                    }
                }
            }
            return binaryTree.root;
        }

        public static BinaryTree ParseExpression(string expression)
        {
            var binaryTree = new BinaryTree();
            BinaryTreeNode currentNode = null;
            for (int i = 0; i < expression.Length; i++)
            {
                if (IsBooleanValue(expression[i].ToString()))
                {
                    var node = new BinaryTreeNode();
                    node.value = expression[i].ToString();
                    node.parent = currentNode;
                    if (binaryTree.root == null)
                    {
                        binaryTree.root = node;
                        currentNode = node;
                    }
                    else
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = node;
                        }
                        else
                        {
                            currentNode.right = node;
                        }
                        if (currentNode.value == "!" && currentNode.parent != null)
                        {
                            currentNode = currentNode.parent;
                        }
                    }
                }
                else
                {
                    if (expression[i].ToString() == "(")
                    {
                        var lastbracket = GetIndexOfClosedBracket(expression, i);
                        var node = ParseSubTree(expression.Substring(i + 1, lastbracket - i - 1));
                        if (currentNode == null)
                        {
                            binaryTree.root = node;
                            currentNode = node;
                        }
                        else if (currentNode.left == null)
                        {
                            currentNode.left = node;
                        }
                        else
                        {
                            currentNode.right = node;
                        }
                        i = lastbracket;
                    }
                    else if (expression[i].ToString() == "!")
                    {
                        var node = new BinaryTreeNode();
                        node.value = expression[i].ToString();
                        node.parent = currentNode;
                        if (currentNode == null)
                        {
                            binaryTree.root = node;
                            currentNode = node;
                        }
                        else if (currentNode.left == null)
                        {
                            currentNode.left = node;
                        }
                        else
                        {
                            currentNode.right = node;
                        }
                        currentNode = node;
                    }
                    else if (expression[i].ToString() != ")")
                    {
                        var parentNode = currentNode.parent;
                        if (parentNode == null)
                        {
                            parentNode = new BinaryTreeNode();
                            parentNode.left = currentNode;
                            parentNode.value = expression[i].ToString();
                            binaryTree.root = parentNode;
                        }
                        currentNode = parentNode;
                    }
                }
            }
            return binaryTree;
        }

        static void Main(string[] args)
        {
            //var expression = Console.ReadLine();
            var expression = "((T&F)|!F)&(T&F)";
            var binaryTree = ParseExpression(expression);
            binaryTree.Display();
            Console.ReadKey();
        }
    }
}