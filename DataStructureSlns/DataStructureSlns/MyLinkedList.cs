/*
 * 自定义单项链表
 * 
 * 功能:
 * 1.添加元素
 * 2.指定位置插入元素
 * 3.根据索引删除元素
 */

namespace DataStructureSlns
{
    using System; 

    /// <summary>
    /// 自定义单向链表
    /// </summary>
    public class MyLinkedList
    {
        private int count; //元素数量
        private Node head;//头指针

        public int Count
        {
            get { return count; }
        }

        public object this[int index]
        {
            get { return GetByIndex(index).item; }
            set { GetByIndex(index).item=value; }
        }

        public void Add(object value)
        {
            Node newNode = new Node(value);
            if (head==null)
            {
                //如果链表为空则作为头指针
                head=newNode;
            }
            else
            {
                GetByIndex(count-1).next=newNode;
            }
            count++;
        }

        public void Insert(int index, object value)
        {
            Node tempNode;
            if (index==0)
            {
                if (head==null)
                {
                    head=new Node(value);
                }
                else
                {
                    tempNode=new Node(value);
                    tempNode.next=head;
                    head=tempNode;
                }
            }
            else
            {
                Node prevNode = GetByIndex(index-1);  //查找插入点的元素
                Node nextNode = prevNode.next;  //插入点元素的尾结点
                tempNode=new Node(value); //新元素
                prevNode.next=tempNode; //设置插入位置元素的尾结点
                tempNode.next=nextNode; //设置新元素的头结点
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index==0)
            {
                head=head.next;
            }
            else
            {
                Node prevNode = GetByIndex(index-1);
                if (prevNode.next==null)
                {
                    throw new ArgumentOutOfRangeException("Index", "");
                }

                prevNode.next=prevNode.next.next;
            }
            count--;
        }

        Node GetByIndex(int index)
        {
            if ((index<0)||(index>=count))
            {
                throw new ArgumentOutOfRangeException("Index", "");
            }

            Node tempNode = head;

            for (int i = 0; i < index; i++)
            {
                tempNode=tempNode.next;
            }

            return tempNode;
        }

        public class Node
        {
            public Node(object value)
            {
                item=value;
            }

            public object item;

            public Node next;

            public override string ToString()
            {
                return item.ToString();
            }
        }
    } 
}
