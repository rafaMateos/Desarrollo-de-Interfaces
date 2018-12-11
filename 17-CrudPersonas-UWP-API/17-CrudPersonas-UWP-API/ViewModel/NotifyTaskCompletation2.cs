﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_CrudPersonas_UWP_API.ViewModel
{
    /*No termino de comprender como utilizar esto. FERNANDO AYUDAME*/

    public sealed class NotifyTaskCompletation2<TResult> : clsVMBase //INotifyPropertyChanged esto ya no hace falta nuestra clase clsVMBase es mejon
    {

        #region PropiedadesPublicas

        //public event PropertyChangedEventHandler PropertyChanged; Esto no!!! utiliza clsVMBase que es mejo
        public Task<TResult> Task { get; private set; }
        public TResult Result
        {
            get { return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult); }
        }
        public TaskStatus Status { get { return Task.Status; } }
        public bool IsCompleted { get { return Task.IsCompleted; } }
        public bool IsNotCompleted { get { return !Task.IsCompleted; } }
        public bool IsSuccessfullyCompleted
        {
            get
            {
                return Task.Status == TaskStatus.RanToCompletion;
            }
        }
        public bool IsCanceled { get { return Task.IsCanceled; } }
        public bool IsFaulted { get { return Task.IsFaulted; } }
        public AggregateException Exception { get { return Task.Exception; } }
        public Exception InnerException
        {
            get
            {
                return (Exception == null) ? null : Exception.InnerException;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return (InnerException == null) ? null : InnerException.Message;
            }
        }
        #endregion


        #region Metodos
        public NotifyTaskCompletation2(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
        }
        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
            }
            //var propertyChanged = PropertyChanged; Noob, variables de tipo pato :'(
            //¿Porque comprueba si es null?
            /*
            if (propertyChanged == null)
                return;
                */
            NotifyPropertyChanged("Status");
            NotifyPropertyChanged("IsCompleted");
            NotifyPropertyChanged("IsNotCompleted");
            if (task.IsCanceled)
            {
                NotifyPropertyChanged("IsCanceled");
            }
            else if (task.IsFaulted)
            {
                NotifyPropertyChanged("IsFaulted");
                NotifyPropertyChanged("Exception");
                NotifyPropertyChanged("InnerException");
                NotifyPropertyChanged("ErrorMessage");
            }
            else
            {
                NotifyPropertyChanged("IsSuccessfullyCompleted");
                NotifyPropertyChanged("Result");
            }
        }
        #endregion

    }
}


