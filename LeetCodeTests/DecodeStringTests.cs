namespace Tests;
using LeetCodeSolutions;
 public class DecodeStringTests {
  private DecodeStringSolution _solution;
  public DecodeStringTests (){
      _solution = new();
  }
  [Fact]
  public void Example1(){
    Assert.Equal("aaabcbc", _solution.DecodeString("3[a]2[bc]"));
  }
}
