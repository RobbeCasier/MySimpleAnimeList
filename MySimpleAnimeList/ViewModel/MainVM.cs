using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using MySimpleAnimeList.Model;
using MySimpleAnimeList.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleAnimeList.ViewModel
{
    class MainVM : ViewModelBase
    {
        EntryWindow ew;
        public ObservableCollection<AnimeItem> AllEntries { get; set; } = new ObservableCollection<AnimeItem>();

        private AnimeItem _newItem;
        public AnimeItem NewItem
        {
            get
            {
                return _newItem;
            }
            set
            {
                _newItem = value;

                
            }
        }
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

        public RelayCommand AddEntry
        {
            get
            {
                return new RelayCommand(AddNewEntry);
            }
        }

        public RelayCommand AddEntryToList
        {
            get
            {
                return new RelayCommand(AddNewEntryToList);
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
            //setup savefiledialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = "MyAnimeList";
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "Json File (*.json)|*.json";
            saveFileDialog.OverwritePrompt = true;

            //open savefiledialog
            //https://stackoverflow.com/questions/23539219/dialogresult-ok-on-savefiledialog-not-work
            bool? result = saveFileDialog.ShowDialog();

            //if person clicked save
            if ((bool)result)
            {
                string json = JsonConvert.SerializeObject(AllEntries.ToArray());
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        private void AddNewEntry()
        {
            NewItem = new AnimeItem();
            ew = new EntryWindow();
            ew.DataContext = this;
            ew.Show();
        }

        void AddNewEntryToList()
        {
            AllEntries.Add(NewItem);
            if (ew != null)
            {
                ew.Close();
                ew = null;
            }
        }
    }
}
