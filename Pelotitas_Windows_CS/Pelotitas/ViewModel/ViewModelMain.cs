using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelotitas
{
    public class ViewModelMain : clsVMBase
    {

        private int _top;
        private int _left;


        public int top{
            get {

                return _top;
            }
            set {

                _top = value;
                NotifyPropertyChanged("top");
            }
            

        }


        public int left {

            get {

                return _left;


            }
            set {

                _left = value;
                NotifyPropertyChanged("left");
            }
        }

       

    }
}
