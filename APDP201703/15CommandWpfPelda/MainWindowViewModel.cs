using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _15CommandWpfPelda
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private CancellationTokenSource cts = null;

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

        public async void Start()
        {
            cts = new CancellationTokenSource();
            var task = new Task(() => {
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

        }

        public void Stop()
        {
            if (cts==null) { return; }
            cts.Cancel();
        }
    }
}
