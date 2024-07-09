using CormenIntoductionToAlgorithms.DataStructures.Trees.BinaryTree;

namespace CormenIntoductionToAlgorithms.Tests;

public class BinaryTreeTests
{
    [Fact]
    public void InorderTreeTraversalTest()
    {
        Check(TreeMethods.InorderTreeWalk);
    }

    [Fact]
    public void InorderTreeTraversal_Nonrecursive_Test()
    {
        Check(TreeMethods.InorderTreeWalk_NonRecursive);
    }

    [Fact]
    public void InorderTreeTraversal_NonrecursiveWithNMemory_Test()
    {
        Check(TreeMethods.InorderTreeWalk_NonRecursiveWithNMemory);
    }

    [Fact]
    public void InorderTreeWalk_NonRecursiveWithStack_Test()
    {
        Check(TreeMethods.InorderTreeWalk_NonRecursiveWithStack);
    }

    // TODO: накидать кейсов
    private static void Check(Action<Node, Action<Node>> act)
    {
        Check1(act);
        Check2(act);
    }

    private static void Check1(Action<Node, Action<Node>> act)
    {
        var node =
            ___(6,
                ___(5,
                    ___(2),
                    ___(5)),
                ___(7,
                    null,
                    ___(8)));

        var keysFromWalk = new List<int>();
        act(node, n => keysFromWalk.Add(n.Key));

        List<int> expected = [2, 5, 5, 6, 7, 8];
        Assert.Equivalent(expected, keysFromWalk);
    }

    private static void Check2(Action<Node, Action<Node>> act)
    {
        var node =
            ___(8,
                ___(3,
                    null,
                    ___(4,
                        null,
                        ___(6,
                            ___(5),
                            ___(7)))),
                ___(9,
                    null,
                    ___(10,
                        null,
                        ___(12,
                            ___(11),
                            ___(13)))));

        var keysFromWalk = new List<int>();
        act(node, n => keysFromWalk.Add(n.Key));

        List<int> expected = [3,4,5,6,7,8,9,10,11,12];
        Assert.Equivalent(expected, keysFromWalk);
    }


    //InorderTreeWalk_NonRecursiveWithStack

    private static Node ___(int key, Node? left = null, Node? right = null)
    {
        var node = new Node
        {
            Key = key,
            Left = left,
            Right = right,
        };

        if (left is not null)
        {
            left.Parent = node;
        }

        if (right is not null)
        {
            right.Parent = node;
        }

        return node;
    }
}
