using System.Threading;

namespace Monitor
{
    // TODO: Use SpinLock to protect this structure.
    public class AnotherClass
    {
        private int _value;
        private SpinLock _spinLock = new SpinLock(false);

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
            bool locked = false;
            try
            {
                _spinLock.Enter(ref locked);
                _value++;
            }
            finally
            {
                if (locked)
                    _spinLock.Exit();
            }
        }

        public void Decrease()
        {
            bool locked = false;
            try
            {
                _spinLock.Enter(ref locked);
                _value--;
            }
            finally
            {
                if (locked) _spinLock.Exit();
            }
        }
    }
}
