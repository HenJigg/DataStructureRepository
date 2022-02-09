/*
 * 自定义的双链表实现
 * 
 * 功能：
 * 1.指定位置前后插入元素
 * 2.结点前后插入元素
 * 3.移除元素
 */ 

namespace DataStructureSlns
{
    using System; 

    public class MyLinkedList<T>
    {
        private int count; //元素数量
        private Node<T> head;//头指针

        public int Count
        {
            get { return count; }
        }

        public object this[int index]
        {
            get { return GetNodeByIndex(index).item; }
            set { GetNodeByIndex(index).item=value; }
        }

        /// <summary>
        /// 根据索引获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private Node<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出范围");
            }

            Node<T> tempNode = this.head;
            for (int i = 0; i < index; i++)
            {
                tempNode = tempNode.Next;
            }

            return tempNode;
        }

        /// <summary>
        /// 在尾节点后插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void AddAfter(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                Node<T> lastNode = this.GetNodeByIndex(this.count - 1);
                // 调整插入节点与前驱节点指针关系
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
            }
            this.count++;
        }

        /// <summary>
        /// 在尾节点前插入新节点
        /// </summary>
        /// <param name="value"></param>
        public void AddBefore(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (this.head == null)
            {
                // 如果链表当前为空则置为头结点
                this.head = newNode;
            }
            else
            {
                Node<T> lastNode = this.GetNodeByIndex(this.count - 1);
                Node<T> prevNode = lastNode.Prev;
                // 调整倒数第2个节点与插入节点的关系
                prevNode.Next = newNode;
                newNode.Prev = prevNode;
                // 调整倒数第1个节点与插入节点的关系
                lastNode.Prev = newNode;
                newNode.Next = lastNode;
            }
            this.count++;
        }

        /// <summary>
        /// 在指定位置后插入新节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertAfter(int index, T value)
        {
            Node<T> tempNode;
            if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new Node<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value);
                    tempNode.Next = this.head;
                    this.head.Prev = tempNode;
                    this.head = tempNode;
                }
            }
            else
            {
                Node<T> prevNode = this.GetNodeByIndex(index); // 获得插入位置的节点
                Node<T> nextNode = prevNode.Next; // 获取插入位置的后继节点
                tempNode = new Node<T>(value);
                // 调整插入节点与前驱节点指针关系
                prevNode.Next = tempNode;
                tempNode.Prev = prevNode;
                // 调整插入节点与后继节点指针关系
                if (nextNode != null)
                {
                    tempNode.Next = nextNode;
                    nextNode.Prev = tempNode;
                }
            }
            this.count++;
        }

        /// <summary>
        /// 在指定位置前插入新节点
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void InsertBefore(int index, T value)
        {
            Node<T> tempNode;
            if (index == 0)
            {
                if (this.head == null)
                {
                    tempNode = new Node<T>(value);
                    this.head = tempNode;
                }
                else
                {
                    tempNode = new Node<T>(value);
                    tempNode.Next = this.head;
                    this.head.Prev = tempNode;
                    this.head = tempNode;
                }
            }
            else
            { 
                var lastNode = GetNodeByIndex(index); 
                var firstNode = lastNode.Prev; 
                tempNode=new Node<T>(value); 
                firstNode.Next=tempNode;
                tempNode.Prev=firstNode; 
                tempNode.Next=lastNode; 
                lastNode.Prev=tempNode; 
            }
            this.count++;
        }

        /// <summary>
        /// 移除指定位置的节点
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                Node<T> prevNode = this.GetNodeByIndex(index - 1);
                if (prevNode.Next == null)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出范围");
                }

                Node<T> deleteNode = prevNode.Next;
                Node<T> nextNode = deleteNode.Next;
                prevNode.Next = nextNode;
                if (nextNode != null)
                {
                    nextNode.Prev = prevNode;
                }

                deleteNode = null;
            }
            this.count--;
        }

        public class Node<F>
        {
            public Node(F value)
            {
                item=value;
            }

            public object item;

            public Node<F> Next;

            public Node<F> Prev;

            public override string ToString()
            {
                return item.ToString();
            }
        }
    }
}
