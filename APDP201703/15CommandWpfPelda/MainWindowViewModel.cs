using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _15CommandWpfPelda
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            startCommand = new SajatParancs((param) => Start(), (param)=>!IsWorking);
            stopCommand = new SajatParancs((param) => Stop(), (param) => IsWorking);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private CancellationTokenSource cts = null;
        private Task task = null;

        private int progressValue = 0;

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                if (value==ProgressValue) { return; }
                progressValue = value;
                OnPropertyChanged(nameof(ProgressValue));
            }
        }

        private ICommand startCommand;
        public ICommand StartCommand { get { return startCommand; } }

        private ICommand stopCommand;
        public ICommand StopCommand { get { return stopCommand; } }

        public bool IsWorking
        {
            get
            {
                if (task == null) { return false; }
                switch (task.Status)
                {
                    case TaskStatus.Created:
                    case TaskStatus.RanToCompletion:
                    case TaskStatus.Canceled:
                    case TaskStatus.Faulted:
                        //nem fut a task
                        return true;
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingToRun:
                    case TaskStatus.WaitingForChildrenToComplete:
                    case TaskStatus.Running:
                        //fut a task
                        return true;
                    default:
                        //ismeretlen státusz, nincs a program erre felkészítve
                        throw new ArgumentOutOfRangeException(string.Format("task.Status ismeretlen: {0}", task.Status));
                }
            }
        }


        public async void Start()
        {
            cts = new CancellationTokenSource();
            task = new Task(() => {
                for (int i = 0; i < 100; i++)
                {
                    if (cts.Token.IsCancellationRequested)
                    {
                        ProgressValue = 0;
                    }
                    cts.Token.ThrowIfCancellationRequested();
                    ProgressValue=i;
                    Thread.Sleep(20);
                }
            },cts.Token);

            task.Start();
            try
            {
                await Task.WhenAll(task);
            }
            catch (OperationCanceledException)
            { //ide akkor jövünk, ha a taskot megszakították
            }
            finally
            {
                CommandManager.InvalidateRequerySuggested();
            }

            task = null;

        }

        public void Stop()
        {
            if (cts==null) { return; }
            cts.Cancel();
        }
    }
}
