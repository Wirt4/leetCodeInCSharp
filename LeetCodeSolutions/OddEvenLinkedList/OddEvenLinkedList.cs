using System.Diagnostics.Tracing;

namespace LeetCodeSolutions;
public class OddEvenLinkedListSolution
{
    private class ListWrapper
    {
        public ListNode? Head;
        public ListNode? Tail;

        public void Add(ref ListNode node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.next = node;
            Tail = Tail.next;
        }
    }

    private class ListIterator
    {
        private int position;
        private ListNode current;
        public ListIterator(ListNode head)
        {
            current = head;
            position = 1;
        }

        public bool PositionIsEven()
        {
            return position % 2 == 0;
        }

        public bool HasRemainingListItems()
        {
            return current != null;
        }

        public void Advance()
        {
            current = current.next;
            position++;
        }

        public ref ListNode CurrentNode => ref current;
    }

    public ListNode OddEvenList(ListNode head)
    {
        ListWrapper evens = new();
        ListWrapper odds = new();
        ListIterator it = new(head);

        while (it.HasRemainingListItems())
        {
            if (it.PositionIsEven())
            {
                evens.Add(ref it.CurrentNode);
            }
            else
            {
                odds.Add(ref it.CurrentNode);
            }
            it.Advance();
        }

        odds.Tail.next = evens.Head;
        evens.Tail.next = null;
        return odds.Head;
    }
}
