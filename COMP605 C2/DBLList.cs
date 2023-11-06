using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace COMP605_C2
{
    internal class DBLList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public Node Current { get; set; }
        public int Counter { get; set; }

        public DBLList()
        {
            Head = null;
            Tail = null;
            Current = null;
            Counter = 0;
        }

        // Operations
        #region Insert
        // Add to front
        public void InsertAtFront(Node node)
        {
            // Check if list is null
            if (Head == null)
            {   // List is empty!! Make each Head, Tail and Current the new node.
                Head = node;
                Tail = node;
                Current = node;
            }

            else
            {   // Attach the list to the new node
                node.Next = Head;
                Head.Prev = node;

                // Reassign Head to new node to keep it at top of stack
                Head = node;
                Current = node;
            }
            Counter++;
        }

        // Add to end
        public void InsertAtRear(Node node)
        {
            // Check if list is null
            if (Head == null)
            {   // List is empty!! Make each Head, Tail and Current the new node.
                Head = node;
                Tail = node;
                Current = node;
            }

            else
            {   // Insert node at the end of the list
                Tail.Next = node;
                node.Prev = Tail;

                // Reassign the Tail to the new node
                Tail = node;
                Current = node;
            }
            Counter++;
        }

        // Add Before
        public bool InsertBefore(Node node, Node targetNode)
        {
            bool inserted = false;
            if (Head == null)
            {   // List is empty!! 
                return inserted;
            }

            if (targetNode.Word == Head.Word)
            {   // Node inserted as new Head
                InsertAtFront(node);
                inserted = true;
                return inserted;
            }

            Current = Head;

            while (Current != null && !inserted)
            {   // Traverse the list to find the target node
                if (Current.Word == targetNode.Word)
                {   // Target node (locked and) found
                    node.Next = Current;
                    node.Prev = Current.Prev;

                    if (Current.Prev != null)
                    {
                        Current.Prev.Next = node;
                    }

                    Current.Prev = node;
                    inserted = true;
                    Counter++;
                }
                else
                {   // Traverse the list
                    Current = Current.Next; // Assign to next node in the list
                }
            }

            return inserted;
        }

        // Add After
        public bool InsertAfter(Node node, Node targetNode)
        {
            bool inserted = false;
            if (Head == null)
            {   // List is empty!! 
                return inserted;
            }

            Current = Head;

            if (targetNode.Word == Head.Word)
            {   // Node inserted as new Head
                InsertAtFront(node);
                inserted = true;
            }
            else
            {
                Current = Head;

                while (Current != null && !inserted)
                { // Traverse the list
                    if (Current.Word == targetNode.Word)
                    {   // Target node (locked and) found
                        if (Current == Tail)
                        {   // Reassign the tail!
                            InsertAtRear(node);
                        }
                        else
                        {   // Attach list to new node
                            node.Next = Current.Next;
                            node.Prev = Current;
                            node.Next.Prev = node;
                            Current.Next = node;
                            Current = node;
                        }
                        inserted = true;
                        Counter++;
                    }
                    else
                    {   // Traverse the list
                        Current = Current.Next; // Assign to next node in list
                    }
                }
            }
            return inserted;
        }
        #endregion

        #region Delete
        // Delete at Front
        public Node DeleteAtFront()
        {
            if (Head == null)
            {   // List is empty!!
                return null;
            }
            else
            {
                Node nodeToRemove = new Node();
                nodeToRemove = Head;

                if (Head == Tail)
                {   // Code broke with only one node in the dictionary, this is a check to make sure it doesn't break
                    Head = null;
                    Tail = null;
                    Current = null;
                }
                else
                {   // Reassign Head to next node in list
                    Head = Head.Next;
                    Head.Prev = null;
                    Current = Head;
                }

                Counter--;

                return nodeToRemove;
            }
        }

        // Delete at End
        public Node DeleteAtEnd()
        {
            if (Head == null)
            {   // List is empty
                return null;
            }
            else
            {
                Node nodeToRemove = new Node();
                nodeToRemove = Tail;

                // Reassign Tail to previous node in list
                Tail = Tail.Prev;
                Tail.Next = null;
                Current = Tail;
                Counter--;

                return nodeToRemove;
            }
        }

        // Delete Node
        public Node DeleteNode(Node nodeToDelete)
        {
            Node nodetoRemove = null;
            if (Head == null)
            { // List is empty!!
                nodetoRemove = null;
            }
            else if (Head.Word == nodeToDelete.Word)
            { // Node to remove is the Head
                nodetoRemove = Head;
                DeleteAtFront();
            }
            else if (Tail.Word == nodeToDelete.Word)
            { // Node to remove is the Tail
                nodetoRemove = Head;
                DeleteAtEnd();
            }
            else
            { // Node in middle, traverse through the list
                Current = Head;
                bool deleted = false;
                while (Current != null && !deleted)
                {   // Not at the end of the list or found
                    if (Current.Word == nodeToDelete.Word)
                    {   // Found node!! Use the previous node and next node to remove Current node from list
                        nodetoRemove = Current;
                        Current.Next.Prev = Current.Prev;
                        Current.Prev = Current.Next;
                        deleted = true;
                        Counter--;
                    }
                    Current = Current.Next;
                }
            }
            return nodetoRemove;
        }
        #endregion

        #region Find/Search
        public int Search(Node nodeToFind)
        {
            int pos = 0; // Returns position of node. (0 if not found)

            if (Head == null)
            {   // List is empty!!
                return pos;
            }
            else
            {
                Current = Head;
                bool found = false;
                while (Current != null && !found)
                {   // Traverse list
                    if (Current.Word == nodeToFind.Word)
                    {   // Found the node!!
                        found = true;
                    }
                    else
                    {   // Step to next node
                        Current = Current.Next;
                    }
                    pos++;
                }
                if (!found) { pos = 0; }
            }
            return pos;
        }
        #endregion

        #region ToPrint
        // Print method to output the contents of the Current node
        public string PrintDictionaryOp()
        {
            Current = Head;

            if (Current == null)
            {
                return "List is empty";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("*** Printing Dictionary Entries ***");
            while (Current != null)
            {
                // Exctraction of object
                sb.AppendLine("Word: " + Current.Word + ", Length: " + Current.LengthCount);
                Current = Current.Next;
                Counter++;
            }

            sb.AppendLine("Number Of Items: " + Counter);

            return sb.ToString();
        }
        #endregion

        //Remember to tile the files to the export of the project
    }
}
