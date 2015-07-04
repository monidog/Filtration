﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Filtration.Common.Services;
using Filtration.Common.ViewModels;
using Filtration.Interface;
using Filtration.ThemeEditor.Providers;
using NLog;
using MessageBox = System.Windows.MessageBox;

namespace Filtration.ThemeEditor.ViewModels
{
    public interface IThemeViewModel : IEditableDocument
    {
        void Initialise(ObservableCollection<ThemeComponentViewModel> themeComponentViewModels, bool newTheme);
        string Title { get; }
        string FilePath { get; set; }
        string Filename { get; }
        string Name { get; set; }
        ObservableCollection<ThemeComponentViewModel> Components { get; set; }
    }

    public class ThemeViewModel : PaneViewModel, IThemeViewModel
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IThemeProvider _themeProvider;
        private readonly IMessageBoxService _messageBoxService;
        private bool _filenameIsFake;
        private string _filePath;

        public ThemeViewModel(IThemeProvider themeProvider,
                              IMessageBoxService messageBoxService)
        {
            _themeProvider = themeProvider;
            _messageBoxService = messageBoxService;

            Components = new ObservableCollection<ThemeComponentViewModel>();


            var icon = new BitmapImage();
            icon.BeginInit();
            icon.UriSource = new Uri("pack://application:,,,/Filtration;component/Resources/Icons/Theme.ico");
            icon.EndInit();
            IconSource = icon;
        }

        public void Initialise(ObservableCollection<ThemeComponentViewModel> themeComponentViewModels, bool newTheme)
        {
            Components = themeComponentViewModels;
            _filenameIsFake = newTheme;
        }

        public bool IsScript { get { return false; } }
        public bool IsTheme { get { return true; } }
        public bool IsDirty { get; private set; }

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                Title = Filename;
            }
        }

        public string Filename
        {
            get { return Path.GetFileName(FilePath); }
        }

        public string Name { get; set; }

        public ObservableCollection<ThemeComponentViewModel> Components { get; set; }

        public void Save()
        {
            if (_filenameIsFake)
            {
                SaveAs();
                return;
            }

            try
            {
                _themeProvider.SaveTheme(this, FilePath);
                //RemoveDirtyFlag();
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error(e);
                }

                _messageBoxService.Show("Save Error", "Error saving filter theme - " + e.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SaveAs()
        {
            var saveDialog = new SaveFileDialog
            {
                DefaultExt = ".filter",
                Filter = @"Filter Theme Files (*.filtertheme)|*.filtertheme|All Files (*.*)|*.*"
            };

            var result = saveDialog.ShowDialog();

            if (result != DialogResult.OK) return;

            var previousFilePath = FilePath;
            try
            {
                FilePath = saveDialog.FileName;
                _themeProvider.SaveTheme(this, FilePath);
                _filenameIsFake = false;
                //RemoveDirtyFlag();
            }
            catch (Exception e)
            {
                if (_logger.IsErrorEnabled)
                {
                    _logger.Error(e);
                }

                _messageBoxService.Show("Save Error", "Error saving theme file - " + e.Message, MessageBoxButton.OK,
                    MessageBoxImage.Error);
                FilePath = previousFilePath;
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
