namespace Tests;
using LeetCodeSolutions;
public class CombinationSumIIITests
{
  private CombinationSumIIISolution _solution;
  public CombinationSumIIITests()
  {
    _solution = new();
  }
  private class Parameters
  {
    public int k;
    public int n;
  }
  private void TestParams(IList<IList<int>> desired, Parameters parameters)
  {
    IList<IList<int>> actual = _solution.CombinationSum3(parameters.k, parameters.n);
    Assert.Equal(desired, actual);
  }
  [Fact]
  public void ArrayOfOne1()
  {
    Parameters parameters = new()
    {
      k = 1,
      n = 1
    };
    IList<IList<int>> desired = [[1]];
    TestParams(desired, parameters);
  }

  [Fact]
  public void ArrayOfOne2()
  {
    Parameters parameters = new()
    {
      k = 1,
      n = 7
    };
    IList<IList<int>> desired = [[7]];
    TestParams(desired, parameters);
  }
  [Fact]
  public void ArrayOfTwo1()
  {
    Parameters parameters = new()
    {
      k = 2,
      n = 3
    };
    IList<IList<int>> desired = [[1, 2]];
    TestParams(desired, parameters);
  }
}
