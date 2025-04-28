using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppWvvmCode.Commands
{
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc == null)
            {
                return true;
            }
            return this.CanExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            if (ExcuteAction == null)
            {
                return;
            }
            this.ExcuteAction(parameter);
        }

        public Action<object> ExcuteAction { get; set; }
        public Func<object, bool> CanExecuteFunc { get; set; }
    }
}
