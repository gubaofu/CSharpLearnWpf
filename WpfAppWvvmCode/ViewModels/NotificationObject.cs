using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWvvmCode.ViewModels
{
    /* 作为 ViewModel 的基类，具有通知能力
     * 这是 WVVM 的基础
     */
    class NotificationObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // 属性改变，触发事件；
        public void RaisePropertyChanged(string propertyName)
        {
            // 简化代码 ============================================
            // 简化前 ======
            //if (this.PropertyChanged == null)
            //{
            //    return;
            //}

            //this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // 简化后 ======
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // ========================================================
        }
    }
}
