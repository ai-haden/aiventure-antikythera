using System;
using System.Collections;
using System.Drawing;

namespace FormControls.Items
{
    public class DialThreshold
    {
        private Color _color = Color.Empty;
        private double _startValue = 0.0;
        private double _endValue = 1.0;

        public DialThreshold() { }

        public Color Color
        {
            set { this._color = value; }
            get { return this._color; }
        }

        public double StartValue
        {
            set { this._startValue = value; }
            get { return this._startValue; }
        }

        public double EndValue
        {
            set { this._endValue = value; }
            get { return this._endValue; }
        }
        
        public bool IsInRange(double val)
        {
            if (val > this.EndValue)
                return false;

            if (val < this.StartValue)
                return false;

            return true;
        }
    }
    
    public class DialThresholdCollection : CollectionBase
    {
        private bool _IsReadOnly = false;

        public DialThresholdCollection() { }

        public virtual DialThreshold this[int index]
        {
            get { return (DialThreshold)InnerList[index]; }
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
        public virtual void Add(DialThreshold sector)
        {
            InnerList.Add(sector);
        }
        /// <summary>
        /// Remove an object from the collection
        /// </summary>
        /// <param name="sector"></param>
        /// <returns></returns>
        public virtual bool Remove(DialThreshold sector)
        {
            bool result = false;

            //loop through the inner array's indices
            for (int i = 0; i < InnerList.Count; i++)
            {
                //store current index being checked
                DialThreshold obj = (DialThreshold)InnerList[i];

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
        public bool Contains(DialThreshold sector)
        {
            //loop through the inner ArrayList
            foreach (DialThreshold obj in InnerList)
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
        /// <param name="DialThresholdArray">The dial threshold array.</param>
        /// <param name="index">The index.</param>
        public virtual void CopyTo(DialThreshold[] DialThresholdArray, int index)
        {
            throw new Exception("This Method is not valid for this implementation.");
        }
    }
}
