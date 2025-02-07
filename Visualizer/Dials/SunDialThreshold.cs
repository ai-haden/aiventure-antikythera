using System;
using System.Collections;
using System.Drawing;

namespace FormControls.Dials
{
    public class SundialThreshold
    {
        private Color _color = Color.Empty;
        private double _endValue = 365.25;

        public SundialThreshold()
        {
            StartValue = 0.0;
        }

        public Color Color { set { _color = value; } get { return _color; } }

        public double StartValue { get; set; }

        public double EndValue { set { _endValue = value; } get { return _endValue; } }
        
        public bool IsInRange(double val)
        {
            if (val > this.EndValue)
                return false;

            if (val < this.StartValue)
                return false;

            return true;
        }
    }
    
    public class SundialThresholdCollection : CollectionBase
    {
        private const bool _IsReadOnly = false;

        public SundialThresholdCollection() { }

        public virtual SundialThreshold this[int index]
        {
            get { return (SundialThreshold)InnerList[index]; }
            set { InnerList[index] = value; }
        }

        public virtual bool IsReadOnly
        {
            get { return _IsReadOnly; }
        }
        /// <summary>
        /// Add an object to the collection
        /// </summary>
        /// <param name="sector"></param>
        public virtual void Add(SundialThreshold sector)
        {
            InnerList.Add(sector);
        }
        /// <summary>
        /// Remove an object from the collection
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public virtual bool Remove(SundialThreshold sector)
        {
            bool result = false;

            //loop through the inner array's indices
            for (int i = 0; i < InnerList.Count; i++)
            {
                //store current index being checked
                SundialThreshold obj = (SundialThreshold)InnerList[i];

                //compare the values of the objects
                if ((obj.StartValue == sector.StartValue) &&
                    (obj.EndValue == sector.EndValue))
                {
                    //remove item from inner ArrayList at index i
                    InnerList.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Check if the object is containing in the collection
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public bool Contains(SundialThreshold sector)
        {
            //loop through the inner ArrayList
            foreach (SundialThreshold obj in InnerList)
            {
                //compare the values of the objects
                if ((obj.StartValue == sector.StartValue) &&
                    (obj.EndValue == sector.EndValue))
                {
                    //if it matches return true
                    return true;
                }
            }
            //no match
            return false;
        }
        /// <summary>
        /// Copy the collection
        /// </summary>
        /// <param name="sundialThresholdArray">The dial threshold array.</param>
        /// <param name="index">The index.</param>
        public virtual void CopyTo(SundialThreshold[] sundialThresholdArray, int index)
        {
            throw new Exception("This Method is not valid for this implementation.");
        }
    }
}
