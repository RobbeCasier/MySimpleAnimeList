using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleAnimeList.ViewModel
{
    class MainVM : ViewModelBase
    {
        public RelayCommand New
        {
            get
            {
                return new RelayCommand(NewFile);
            }
        }
        public RelayCommand Open
        {
            get
            {
                return new RelayCommand(OpenFile);
            }
        }
        public RelayCommand Save
        {
            get
            {
                return new RelayCommand(SaveFile);
            }
        }
        public RelayCommand SaveAs
        {
            get
            {
                return new RelayCommand(SaveFileAs);
            }
        }

        private void NewFile()
        {

        }
        private void OpenFile()
        {

        }

        private void SaveFile()
        {

        }

        private void SaveFileAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = "MyAnimeList";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "Json File (*.json)|*.json";
            saveFileDialog.OverwritePrompt = true;

            saveFileDialog.ShowDialog();

            string json = ""; //Json convert
            File.WriteAllText(saveFileDialog.FileName, json);
        }
    }
}
