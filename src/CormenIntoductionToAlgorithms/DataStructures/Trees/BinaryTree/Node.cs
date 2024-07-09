using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CormenIntoductionToAlgorithms.DataStructures.Trees.BinaryTree;

public class Node
{
    public required int Key { get; set; }

    public Node? Parent { get; set; }

    public Node? Left { get; set; }

    public Node? Right { get; set; }
}

public static class TreeMethods
{
    /// <summary>
    /// EN: Inorder Traversal
    /// RU: Центрированный (симмитричный) обход дерева
    /// </summary>
    public static void InorderTreeWalk(Node? node, Action<Node> action)
    {
        if (node is not null)
        {
            InorderTreeWalk(node.Left, action);
            action(node);
            InorderTreeWalk(node.Right, action);
        }
    }

    public static void InorderTreeWalk_NonRecursiveWithStack(Node node, Action<Node> action)
    {
        var stack = new Stack<Node>();
        stack.Push(node);
        while (stack.Peek().Left is not null)
        {
            stack.Push(stack.Peek().Left!);
        }

        while (stack.Count > 0)
        {
            node = stack.Pop();
            action(node);

            if (node.Right is not null)
            {
                stack.Push(node.Right);
                while (stack.Peek().Left is not null)
                {
                    stack.Push(stack.Peek().Left!);
                }
            }
        }
    }

    public static void InorderTreeWalk_NonRecursiveWithNMemory(Node node, Action<Node> action)
    {
        var processed = new HashSet<Node>();
        while (node != null)
        {
            if (node.Left is not null && !processed.Contains(node.Left))
            {
                node = node.Left;
                continue;
            }

            if (!processed.Contains(node))
            {
                action(node);
                processed.Add(node);
            }

            if (node.Right is not null && !processed.Contains(node.Right))
            {
                node = node.Right;
                continue;
            }

            node = node.Parent!;
        }
    }

    public static void InorderTreeWalk_NonRecursive(Node root, Action<Node> action)
    {
        Node? node = root;
        while (node.Left is not null)
        {
            node = node.Left;
        }

        Node? wasHere = null;
        while (node is not null)
        {
            action(node);

            if (node.Right is not null && node.Right != wasHere)
            {
                node = node.Right;
                while (node.Left is not null)
                {
                    node = node.Left;
                }
                continue;
            }

            wasHere = node;
            node = node.Parent;
        }
    }
}
