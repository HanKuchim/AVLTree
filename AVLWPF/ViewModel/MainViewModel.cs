using AVLWPF.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using AVLTreeLibrary;


namespace AVLWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private AVLTree avlTree;
        private ObservableCollection<int> treeNodes;
        private string inputValue;
        private ObservableCollection<string> printValues;

        public MainViewModel()
        {
            avlTree = new AVLTree();
            TreeNodes = new ObservableCollection<int>();

            AddCommand = new RelayCommand(AddNumber);
            DeleteCommand = new RelayCommand(DeleteNumber);
            SaveToFileCommand = new RelayCommand(SaveToFile);
        }

        public ObservableCollection<int> TreeNodes
        {
            get { return treeNodes; }
            set
            {
                treeNodes = value;
                OnPropertyChanged();
            }
        }

        public string InputValue
        {
            get { return inputValue; }
            set
            {
                inputValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> PrintValues
        {
            get { return printValues;}
            set
            {
                printValues = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SaveToFileCommand { get; }

        private void AddNumber()
        {
            if (int.TryParse(InputValue, out int number))
            {
                avlTree.Insert(number);
                UpdateTreeView();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.");
            }
        }

        private void DeleteNumber()
        {
            if (int.TryParse(InputValue, out int number))
            {
                avlTree.Delete(number);
                UpdateTreeView();
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid integer.");
            }
        }

        private void SaveToFile()
        {
            // Implement logic to save tree to a file
            // For example, you can use SaveFileDialog
        }

        private void UpdateTreeView()
        {
            TreeNodes.Clear();
            TraverseTree(avlTree.Root);
        }

        private void TraverseTree(AVLNode node)
        {
            List<string> treeAsStringList = avlTree.GetTreeAsStringList();
            PrintValues = new ObservableCollection<string>(treeAsStringList);
            OnPropertyChanged(nameof(PrintValues));
        }
        

    }
}
