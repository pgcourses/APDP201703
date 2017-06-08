using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _15CommandWpfPelda
{
    public class SajatParancs : ICommand
    {
        private Action<object> execute = null;
        private Func<object, bool> canexecute = null;

        /// <summary>
        /// Ha a parancs mindig hívható, akkor nem kell második paraméter
        /// </summary>
        /// <param name="execute">Egy Action, amit hívni kell, ha a parancsot végrehajtják</param>
        public SajatParancs(Action<object> execute)
        {
            this.execute = execute;
        }

        /// <summary>
        /// Ha a parancs nem mindig hívható, akkor kell egy függvény, ami megmondja, hogy most hívható-e vagy sem.
        /// </summary>
        /// <param name="execute">Egy Action, amit hívni kell, ha a parancsot végrehajtják</param>
        /// <param name="canexecute">Egy Func ami megmondja, hogy a parancsot lehet-e hívni, vagy sem</param>
        public SajatParancs(Action<object> execute, Func<object, bool> canexecute) : this(execute)
        {
            this.canexecute = canexecute;
        }

        /// <summary>
        /// Egy esemény, ami azt jelzi, hogy változhat-e a parancshívás állapota.
        /// Ha van CanExecute, akkor kötelező implementálni.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Ezt hívja a keretrendszer annak eldöntésére, hogy a parancs hívható-e?
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canexecute == null ? true : canexecute(parameter);
        }

        /// <summary>
        /// Ez a parancs hívása
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
