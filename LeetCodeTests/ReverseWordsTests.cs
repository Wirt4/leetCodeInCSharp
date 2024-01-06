namespace Tests;

using LeetCodeSolutions;

public class ReverseWordsTests{
    [Fact]
    public void oneWord(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("hello", rWords.ReverseWords("hello"));
    }

    [Fact]
    public void oneWord2(){
        ReverseWordsSolution rWords = new ReverseWordsSolution();
        Assert.Equal("goodbye", rWords.ReverseWords("goodbye"));
    }
}