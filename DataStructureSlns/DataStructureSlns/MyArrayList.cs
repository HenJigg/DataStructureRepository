/*
 * 自定义ArrayList
 * 
 * 功能: 
 * 1.添加元素
 * 2.指定位置插入元素
 * 3.根据索引删除元素
 * 4.索引器访问指定位置元素
 * 5.裁剪数组空间
 * 
 * 注:当数组空间超出容器长度,申请*2空间存放新的元素
 */ 

namespace DataStructureSlns
{
    using System;

    /// <summary>
    /// 自定义ArrayList
    /// </summary>
    public class MyArrayList
    {
        private const int defaultCapacity = 4;//默认长度4
        private object[] items;//存放的数组对象
        private int size;//数组大小
        private static readonly object[] emptyArray = new object[0];

        /// <summary>
        /// 数组的容量
        /// </summary>
        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value!=items.Length)
                {
                    if (value<size)
                    {
                        throw new ArgumentOutOfRangeException("Value", "");
                    }

                    if (value>0)
                    {
                        //定义新的内存空间
                        object[] newitems = new object[value];
                        if (size>0)
                        {
                            //把所有元素换到新的数组空间内
                            Array.Copy(items, 0, newitems, 0, size);
                        }
                        items=newitems;
                    }
                    else
                    {
                        //初始化默认长度的数组对象
                        items=new object[defaultCapacity];
                    }
                }
            }
        }

        /// <summary>
        /// 数组元素个数
        /// </summary>
        public int Count
        {
            get { return size; }
        }

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                if ((index<0)||(index>=size))
                {
                    throw new ArgumentOutOfRangeException("Index", "");
                }
                return items[index];
            }
            set
            {
                if ((index<0)||(index>=size))
                {
                    throw new ArgumentOutOfRangeException("Index", "");
                }
                this.items[index]=value;
            }
        }

        public MyArrayList()
        {
            items=emptyArray;
        }

        public MyArrayList(int capacity)
        {
            if (capacity<0)
            {
                throw new ArgumentOutOfRangeException("Capacity", "");
            }

            //初始化指定大小的数组长度对象
            items=new object[capacity];
        }

        public virtual int Add(object value)
        {
            if (size==items.Length)
            {
                //调整数据空间
                EnsureCapacity(size+1);
            }
            items[size]=value;
            return size++;
        }

        public virtual void Insert(int index, object value)
        {
            if (index<0||(index>size))
            {
                throw new ArgumentOutOfRangeException("Index", "");
            }

            if (size==items.Length)
            {
                //调整数组空间
                EnsureCapacity(size+1);
            }

            if (index<size)
            {
                //将插入位置后的所有元素向后移动一位
                Array.Copy(items, index, items, index+1, size-index);
            }

            items[index]=value;//插入元素
            size++;//长度加1
        }

        public virtual void RemoveAt(int index)
        {
            if (index<0||(index>=size))
            {
                throw new ArgumentOutOfRangeException("Index", "");
            }

            size--;
            if (index<size)
            {
                //删除元素后的所有元素向前移动一位
                Array.Copy(items, index+1, items, index, size-index);
            }

            items[size]=null;//最后一位的元素设置为空
        }

        /// <summary>
        /// 裁剪数组空间
        /// </summary>
        public virtual void TrimToSize()
        {
            Capacity=size;
        }

        /// <summary>
        /// 调整数组的容量大小
        /// </summary>
        /// <param name="length"></param>
        void EnsureCapacity(int length)
        {
            if (items.Length<length)
            {
                int capacity = items.Length==0 ? defaultCapacity : items.Length*2;

                if (capacity<length)
                    capacity=length;

                this.Capacity=capacity;
            }
        }
    }
}
