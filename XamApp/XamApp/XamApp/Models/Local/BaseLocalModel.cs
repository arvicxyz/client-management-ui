﻿using SQLite;
using System.ComponentModel;
using XamApp.Models.Interfaces;

namespace XamApp.Models.Local
{
    public class BaseLocalModel : IBaseLocalModel, INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T item, T value, string property)
        {
            if (!item.Equals(value))
            {
                item = value;
                NotifyPropertyChanged(property);
            }
        }
    }
}
