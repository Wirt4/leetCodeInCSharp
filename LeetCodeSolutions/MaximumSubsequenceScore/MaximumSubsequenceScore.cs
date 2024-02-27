namespace LeetCodeSolutions;
public class MaximumSubsequenceScoreSolution
{
    private int[][] getSortedPairs(int[] nums1, int[] nums2)
    {
        PriorityQueue<int[], int> pQueue = new();
        for (int i = 0; i < nums1.Length; i++)
        {
            pQueue.Enqueue([nums2[i], nums1[i]], nums2[i]);
        }

        int[][] allPairs = new int[nums1.Length][];

        int j = 0;

        while (pQueue.Count > 0)
        {
            allPairs[j] = pQueue.Dequeue();
            j++;
        }

        return allPairs;
    }
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {


        int[][] allPairs = getSortedPairs(nums1, nums2);
        PriorityQueue<int[], int> pQueue = new();


        int sum = 0;

        for (int m = 0; m < k; m++)
        {
            sum += allPairs[m][1];
            pQueue.Enqueue(allPairs[m], allPairs[m][0]);
        }

        int max = sum * pQueue.Peek()[0];

        for (int p = k; p < nums1.Length; p++)
        {
            int[] removedPair = pQueue.Dequeue();
            sum -= removedPair[1];

            sum += allPairs[p][1];
            pQueue.Enqueue(allPairs[p], allPairs[p][0]);

            int currentMax = sum * pQueue.Peek()[0];

            if (currentMax > max)
            {
                max = currentMax;
            }


        }

        // now there are k pairs in the priority queue


        return max;

    }
}
