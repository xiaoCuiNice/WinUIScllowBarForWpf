using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUIScllowBarForWpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public MainWindowViewModel()
        {
            DataSource = new List<Data>();
            Random random = new Random();　　//放循环体外初始化
            string _zimu = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";//要随机的字母

            for (int i = 0; i < 1000; i++)
            {
                string _result = "";
                for (int j = 0; j < 6; j++) //循环6次，生成6位数字，10位就循环10次
                {
                    _result += _zimu[random.Next(52)]; //通过索引下标随机

                }
                DataSource.Add(new Data { Index = i + 1, Id = random.Next(100, 1000).ToString(), Name = _result, GirdInfo = random.Next(100, 1000).ToString() ,X1 = random.Next(10000, 1000000) });
            }


        }

        private List<Data> _dataSource;

        public List<Data> DataSource
        {
            get { return _dataSource; }
            set { _dataSource = value; OnPropertyChanged("DataSource"); }
        }



    }

    public class Data
    {

        public int Index { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public string GirdInfo { get; set; }

        public int X1 { get; set; }
    }
}
