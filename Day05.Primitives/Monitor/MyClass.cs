using System;

namespace Monitor
{
    // TODO: Use Monitor (not lock) to protect this structure.
    public class MyClass
    {
        private int _value;
        private Object obj = new Object();

        public int Counter
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public void Increase()
        {
            System.Threading.Monitor.Enter(obj);
            try
            {
                _value++;
            }
            finally
            {
                System.Threading.Monitor.Exit(obj);
            }
        }

        public void Decrease()
        {
            System.Threading.Monitor.Enter(obj);
            try
            {
                _value--;
            }
            finally
            {
                System.Threading.Monitor.Exit(obj);
            }
        }
    }
}
