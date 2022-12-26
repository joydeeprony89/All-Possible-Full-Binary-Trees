Solution s = new Solution();
var answer = s.AllPossibleFBT(5);
foreach(var a in answer)
  Console.WriteLine(a);

public class TreeNode
{
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
  {
    this.val = val;
    this.left = left;
    this.right = right;
  }
}


public class Solution
{
  public IList<TreeNode> AllPossibleFBT(int n)
  {
    var cache = new Dictionary<int, List<TreeNode>>();
    var result = new List<TreeNode>();
    // for n=1 , we can have only one node without any child
    if (n == 1)
    {
      result.Add(new TreeNode(0));
      cache[n] = result;
      return result;
    }
    // for n=1 , it is not possible to have a FBT
    if (n == 2)
    {
      cache[n] = result;
      return result;
    }
    // for n=3 , we can have one root node with one left and one right child.
    if (n == 3)
    {
      var root = new TreeNode(0, new TreeNode(0), new TreeNode(0));
      result.Add(root);
      cache[n] = result;
      return result;
    }
    // when n is even we can not have any FBT
    if (n % 2 == 0) return result;
    // if already cached return. 
    if (cache.ContainsKey(n)) return cache[n];

    // why i increased by 2 ? 
    //we increment 2 at a time because we require to have atleast 2 child(max to max can go as much to make the full BT)
    for (int i = 1; i < n; i += 2)
    {
      var left = AllPossibleFBT(i);
      var right = AllPossibleFBT(n - i - 1); // one node will be always used as root

      //creating the every combination of tree in each steps posible from the elements present in the leftSubTree and rightSubTree
      foreach (var l in left)
      {
        foreach (var r in right)
        {
          var root = new TreeNode(0, l, r);
          result.Add(root);
          cache[n] = result;
        }
      }
    }
    return result;
  }
}